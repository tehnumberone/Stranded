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
            Character chara = new Character();
            return View(chara);
        }
        [HttpPost]
        public IActionResult Save(string name, int charId)
        {
            CharacterContext cc = new CharacterContext();
            cc.CreateChar(name, charId);
            return View("CharacterCreation");
        }
        [HttpPost]
        public IActionResult SelectModel(string name, Character chara)
        {
            chara.CharacterModel = Convert.ToInt32(name);
            return RedirectToAction("CharacterCreation");
        }
    }
}
