using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranded.Models;
using Stranded.Models.ViewModels;

namespace Stranded.Controllers
{
    public class MapController : Controller
    {
        public IActionResult LoadMap()
        {
            return View("Map");
        }
    }
}