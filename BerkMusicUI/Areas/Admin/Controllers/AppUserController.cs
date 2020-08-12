using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
   
        [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppUserController : Controller
        {
            private readonly UserManager<AppUser> userManager;
            private readonly RoleManager<AppUserRole> roleManager;

            public AppUserController(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
            {
                this.userManager = userManager;
                this.roleManager = roleManager;
            }
            public IActionResult Index()
            {
                return View(userManager.Users);
            }

            public async Task<IActionResult> AssignMember(string id)
            {
                AppUser user = await userManager.FindByIdAsync(id);
                await userManager.RemoveFromRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user, "Member");
           
            return RedirectToAction("Index");
            }

            public async Task<IActionResult> AssignAdmin(string id)
            {
                AppUser user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, "Admin");
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
               
            }
        
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
    }
}
       
