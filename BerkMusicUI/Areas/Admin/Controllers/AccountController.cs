using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerkMusicUI.Areas.Admin.Models.ViewModels;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(appUserVM.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, appUserVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Create", "Home");

                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
        
    }
}

