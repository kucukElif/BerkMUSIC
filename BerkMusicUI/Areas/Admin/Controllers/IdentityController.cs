using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class IdentityController : Controller
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public IActionResult Index()
        {
            return View(identityService.GetActive());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Identity model, IFormFile image)
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
                identityService.Add(model);
                return RedirectToAction("Index");


            }
            catch
            {

                return View();
            }

        }

        public IActionResult Edit(Guid id)
        {
            Identity identity = identityService.GetById(id);
            return View(identity);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Identity identity, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (identity.ImagePath != null)
                    {
                        identityService.Update(identity);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "noimage.jpg");
                    identity.ImagePath = "noimage.jpg";

                }
                else
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    identity.ImagePath = image.FileName;
                }
                identityService.Update(identity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }

        }



        public ActionResult Delete(Guid id)
        {
            return View(identityService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Identity identity)
        {
            try
            {
                identityService.Remove(identity.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

