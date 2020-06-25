using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BerkMusicUI.CustomHelper;
using BLL.Abstract;
using DAL;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class NavbarController : Controller
    {
        private readonly INavbarService navbarService;
        public NavbarController(INavbarService navbarService)
        {
            this.navbarService = navbarService;
        }

        public INavbarService NavbarService { get; }

        public IActionResult Index()
        {
            return View(navbarService.GetActive());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NavbarItem model, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", "noimage.jpg");
                    model.ImagePath = "noimage.jpg";
                }
                else
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
              
                
                navbarService.Add(model);
                return RedirectToAction("Index");


            }
            catch
            {

                return View();
            }

        }
        public IActionResult Edit(Guid id)
        {
            NavbarItem navbar = navbarService.GetById(id);
            return View(navbar);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NavbarItem navbar, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (navbar.ImagePath != null)
                    {
                        navbarService.Update(navbar);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "noimage.jpg");
                    navbar.ImagePath = "noimage.jpg";

                }
                else
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    navbar.ImagePath = image.FileName;
                }
                navbarService.Update(navbar);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(navbarService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Layout layout)
        {
            try
            {
                navbarService.Remove(layout.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
