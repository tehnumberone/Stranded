using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Stranded.Converters;
using Stranded.ViewModels;
using Stranded.Repositories;

namespace Stranded.Controllers
{
    public class MapController : Controller
    {
        private readonly CharacterRepo _cr;
        private readonly AccountRepo _ar;
        private readonly ItemRepo _ir;

        public MapController(CharacterRepo cr, AccountRepo ar, ItemRepo ir)
        {
            _ar = ar;
            _cr = cr;
            _ir = ir;
        }

        public IActionResult LoadMap(int characterID)
        {
            if (HttpContext.Session.GetString("Username") == null) { return RedirectToAction("Login", "Account"); }
            var characterConvert = new CharacterToCharacterVM();
            var itemConverter = new ItemToItemVM();
            var tempItemList = new List<ItemViewModel>();
            foreach (Item item in _ir.GetAllItems(0))
            {
                tempItemList.Add(itemConverter.ToItemVM(item));
            }
            var mvm = new MapViewModel
            {
                character = characterConvert.ToCharVM(_cr.GetById(characterID)),
                allitems = tempItemList
            };
            return View("Game", mvm);
        }

        [HttpPost]
        public IActionResult SaveGame(string[] inventoryItems, int hp, int level, int hunger, int hydration, int characterID)
        {
            if (characterID > 0 && level > 0)
            {
                _cr.Update(new Character(characterID, hp, hunger, hydration, level));
                return View();
            }
            else return View();
        }
    }
}