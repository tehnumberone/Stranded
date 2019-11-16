using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranded.Context.MSSQL;
using Stranded.Models;
using Stranded.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stranded.Controllers
{
    public class CharacterController : Controller
    {
        [HttpGet]
        public IActionResult Characters()
        {
            CharacterViewModel cvm = new CharacterViewModel();
            CharacterContext cc = new CharacterContext();
            cvm = cc.GetAllCharacters();
            return View(cvm);
        }

        [HttpGet]
        public IActionResult CharacterCreation(CharacterCreationViewModel ccvm)
        {
            CharacterContext cc = new CharacterContext();
            ccvm.CharModels = cc.LoadCharModels();
            return View(ccvm);
        }

        [HttpPost]
        public IActionResult Save(CharacterCreationViewModel ccvm)
        {   
            CharacterContext cc = new CharacterContext();
            cc.CreateChar(ccvm.Name, ccvm.CharacterModel);
            return View("CharacterCreation",ccvm);
        }

        [HttpPost]
        public IActionResult RemoveCharacter(int Id)
        {
            CharacterViewModel cvm = new CharacterViewModel();
            CharacterContext cc = new CharacterContext();
            cc.RemoveChar(Id);
            return RedirectToAction("Characters", cvm);
        }
    }
}
