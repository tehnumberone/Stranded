using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Library.Models;
using Stranded.ViewModels;
using Stranded.Repositories;
using Stranded.Converters;
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
        [HttpGet]
        public IActionResult Characters()
        {
            if (HttpContext.Session.GetString("Username") == null) { return RedirectToAction("Login", "Account"); }
            var cvm = new CharacterViewModel();
            var charConverter = new CharacterToCharacterVM();
            foreach (Character character in _cr.GetAll(_ar.GetByName(HttpContext.Session.GetString("Username"))))
            {
                cvm.Characters.Add(charConverter.ToCharVM(character));
            }
            return View(cvm);
        }
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
        public IActionResult RemoveCharacter(CharacterViewModel cvm)
        {
            _cr.Delete(cvm.Id);
            return RedirectToAction("Characters");
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
        [HttpPost]
        public IActionResult Play(int Id)
        {
            var character = _cr.GetById(Id);
            return RedirectToAction("LoadMap", "Map", new { characterID = Id });
        }
    }
}
