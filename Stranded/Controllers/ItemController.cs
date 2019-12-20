using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stranded.Models;
using Stranded.Models.ViewModels;
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
            ivm.DBItems = _ir.GetAllItems(ivm.Sortingtype);
            ivm.AllItems = new List<ItemViewModel>();
            foreach (Item item in ivm.DBItems)
            {
                ItemViewModel temp = new ItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemType = item.ItemType,
                    ImageFile = Convert.ToBase64String(item.ImageFile)
                };
                ivm.AllItems.Add(temp);
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
                MemoryStream memoryStream = new MemoryStream();
                icvm.ImageFile.CopyTo(memoryStream);
                Item tempitem = new Item()
                {
                    Name = icvm.Name,
                    ImageFile = memoryStream.ToArray(),
                    ItemType = icvm.ItemType,
                };
                _ir.Create(tempitem);
                return RedirectToAction("AllItems", "Item");
            }
            return View("CreateItem", icvm);
        }
        [HttpPost]
        public IActionResult RemoveItem(ItemViewModel ivm)
        {
            _ir.Delete(ivm.Id);
            return RedirectToAction("AlleItems");
        }
        [HttpPost]
        public IActionResult Sorteer(ItemViewModel ivm)
        {
            if (ivm.Sortingtype == 0) { ivm.Sortingtype = 1; }
            else { ivm.Sortingtype = 0; }
            return RedirectToAction("AllItems", ivm);
        }
    }
}