using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Stranded.Repositories;
using Stranded.ViewModels;
using Stranded.Converters;
using Library.Models;
using Microsoft.AspNetCore.Http;

namespace Stranded.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepo _ar;

        public AccountController(AccountRepo ar)
        {
            _ar = ar;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") != null) { return RedirectToAction("Home", "Index"); }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            if (HttpContext.Session.GetString("Username") != null) { return RedirectToAction("Home", "Index"); }
            if (ModelState.IsValid)
            {
                if (_ar.CheckAccount(lvm.Username, lvm.Password))
                {
                    var acc = _ar.GetByName(lvm.Username);
                    HttpContext.Session.SetString("Username", (lvm.Username));
                    HttpContext.Session.SetInt32("UserID", (acc.Id));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(nameof(lvm.Username), "Incorrect Username or Password");
            }
            return View(lvm);

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("Username") != null) { return RedirectToAction("Home", "Index"); }
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var acc = new Account(rvm.Username, rvm.Password, rvm.Email);
                if (_ar.Create(acc))
                {
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError(nameof(rvm.Username), "This username is already in use.");
                    return View(rvm);
                }
            }
            return View(rvm);
        }
        [HttpGet]
        public IActionResult AllAccounts()
        {
            if (HttpContext.Session.GetString("Username") != "Admin") { return RedirectToAction("Home", "Index"); }
            var avm = new AccountViewModel();
            avm.AllAccounts = new List<AccountViewModel>();
            foreach (Account acc in _ar.GetAllAccounts())
            {
                avm.AllAccounts.Add(AccountToAccountVM.ToAccVM(acc));
            }
            return View(avm);
        }
    }
}