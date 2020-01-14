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
            CharacterToCharacterVM characterConvert = new CharacterToCharacterVM();
            ItemToItemVM itemConverter = new ItemToItemVM();
            var character = _cr.GetById(characterID);
            var mvm = new MapViewModel
            {
                character = characterConvert.ToCharVM(character)
            };
            var tempItemList = new List<ItemViewModel>();
            foreach (Item item in _ir.GetAllItems(0))
            {
                tempItemList.Add(itemConverter.ToItemVM(item));
            }
            mvm.allitems = tempItemList;
            return View("Game", mvm);
        }

        [HttpPost]
        public IActionResult SaveGame(string inventoryitem)
        {
            if (inventoryitem == null)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}