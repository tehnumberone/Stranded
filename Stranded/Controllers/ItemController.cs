using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Stranded.Converters;
using Stranded.ViewModels;
using Stranded.Repositories;

namespace Stranded.Controllers
{
    public class ItemController : Controller
    {

        private readonly ItemRepo _ir;
        public ItemController(ItemRepo ir)
        {
            _ir = ir;
        }
        [HttpGet]
        public IActionResult AllItems(ItemViewModel ivm)
        {
            if (HttpContext.Session.GetString("Username") != "Admin") { return RedirectToAction("Index", "Home"); }
            ivm.AllItems = new List<ItemViewModel>();
            foreach (Item item in _ir.GetAllItems(ivm.Sortingtype))
            {
                ivm.AllItems.Add(ItemToItemVM.ToItemVM(item));
            }

            return View(ivm);
        }
        [HttpGet]
        public IActionResult CreateItem()
        {
            if (HttpContext.Session.GetString("Username") != "Admin") { return RedirectToAction("Index", "Home"); }
            ItemCreationViewModel icvm = new ItemCreationViewModel();
            return View(icvm);
        }
        [HttpPost]
        public IActionResult Save(ItemCreationViewModel icvm)
        {
            if (ModelState.IsValid)
            {
                if (icvm.ImageFile.Length <= 0 || !icvm.ImageFile.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("ImageFile", "Selected file is not an image.");
                    return View("CreateItem", icvm);
                }
                Item tempitem = ItemToItemVM.ToItem(icvm);
                _ir.Create(tempitem);
                return RedirectToAction("AllItems", "Item");
            }
            return View("CreateItem", icvm);
        }
        [HttpPost]
        public IActionResult RemoveItem(ItemViewModel ivm)
        {
            _ir.Delete(ivm.Id);
            return RedirectToAction("AllItems");
        }
        [HttpPost]
        public IActionResult SortByType(ItemViewModel ivm)
        {
            if (ivm.Sortingtype == 0) { ivm.Sortingtype = 1; }
            else { ivm.Sortingtype = 0; }
            return RedirectToAction("AllItems", ivm);
        }
        [HttpGet]
        public IActionResult SelectItem(ItemViewModel ivm)
        {
            if (HttpContext.Session.GetString("Username") == null) { return RedirectToAction("Login", "Account"); }
            Item tempitem = _ir.GetItem(ivm.Id);
            ivm.ImageFile = Convert.ToBase64String(tempitem.ImageFile);
            ivm.Name = tempitem.Name;
            ivm.ItemType = (Stranded.ViewModels.ItemType)tempitem.ItemType;
            return View(ivm);
        }
    }
}