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
        public IActionResult CharacterCreation()
        {
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
            return View(ccvm);
        }

        [HttpPost]
        public IActionResult Save(string Name, int CharacterModel)
        {
            CharacterContext cc = new CharacterContext();
            cc.CreateChar(Name, CharacterModel);
            return View("CharacterCreation");
        }

        [HttpPost]
        public IActionResult RemoveCharacter(int Id)
        {
            CharacterViewModel cvm = new CharacterViewModel();
            CharacterContext cc = new CharacterContext();
            cc.RemoveChar(Id);
            return View("Characters", cvm);
        }

        [HttpPost]
        public IActionResult Character1Selection(string name)
        {
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
            ccvm.Name = name;
            ccvm.CharacterModel = 1;
            return View("CharacterCreation", ccvm);
        }

        [HttpPost]
        public IActionResult Character2Selection(string name)
        {
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
            ccvm.Name = name;
            ccvm.CharacterModel = 2;
            return View("CharacterCreation", ccvm);
        }

        [HttpPost]
        public IActionResult Character3Selection(string name)
        {
            CharacterCreationViewModel ccvm = new CharacterCreationViewModel();
            ccvm.Name = name;
            ccvm.CharacterModel = 3;
            return View("CharacterCreation", ccvm);
        }

    }
}
