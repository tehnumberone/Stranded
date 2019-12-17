using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stranded.Models;
using Stranded.Models.ViewModels;

namespace Stranded.Controllers
{
    public class MapController : Controller
    {
        public IActionResult LoadMap(Character character)
        {
            if (HttpContext.Session.GetString("Username") == null) { return RedirectToAction("Login", "Account"); }
            var mvm = new MapViewModel
            {
                character = character
            };
            return View("Game", mvm);
        }
    }
}