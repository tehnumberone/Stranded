using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Stranded.Models;
using Stranded.Models.ViewModels;
using Stranded.Repositories;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Stranded.Controllers
{
    public class CharacterController : Controller
    {
        private readonly CharacterRepo _cr;
        private readonly AccountRepo _ar;

        public CharacterController(CharacterRepo cr, AccountRepo ar)
        {
            _ar = ar;
            _cr = cr;
        }
        #region character menu

        [HttpGet]
        public IActionResult Characters()
        {
            if (HttpContext.Session.GetString("Username") == null) { return RedirectToAction("Login", "Account"); }
            var cvm = new CharacterViewModel
            {
                Characters = _cr.GetAll(_ar.GetByName(HttpContext.Session.GetString("Username")))
            };
            return View(cvm);
        }

        [HttpPost]
        public IActionResult RemoveCharacter(int Id)
        {
            _cr.Delete(Id);
            return RedirectToAction("Characters");
        }

        [HttpPost]
        public IActionResult Play(int Id)
        {
            var character = _cr.GetById(Id);
            return RedirectToAction("LoadMap", "Map", character);
        }
        #endregion

        [HttpGet]
        public IActionResult CharacterCreation()
        {
            if (HttpContext.Session.GetString("Username") == null) { return RedirectToAction("Login", "Account"); }
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel
            {
                CharModels = _cr.GetAllCharModels()
            };
            return View(ccvm);
        }

        [HttpPost]
        public IActionResult CharacterCreation(CharacterCreationViewModel ccvm)
        {
            if (ModelState.IsValid)
            {
                Account acc = _ar.GetByName(HttpContext.Session.GetString("Username"));
                var c = new Character()
                {
                    Name = ccvm.Name,
                    CharacterModel = ccvm.CharacterModel
                };
                _cr.Create(c, acc);
                return RedirectToAction("Characters");
            }
            else
            {
                ccvm.CharModels = _cr.GetAllCharModels();
                return View(ccvm);
            }
        }
    }
}
