using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerkMusicUI.Areas.Admin.Models.ViewModels;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppUserCreateVM appUserCreateVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = appUserCreateVM.UserName,

                    Email = appUserCreateVM.Email,

                };
                var result = await userManager.CreateAsync(user, appUserCreateVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }


    }


}

