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
    [Authorize(Roles = "Admin")]
    public class PhotoController : Controller
    {
        private readonly IPhotoService photoService;

        public PhotoController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }
        public IActionResult Index()
        {
            return View(photoService.GetActive());
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Photo model, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//noimage", "noimage.jpeg");
                    model.ImagePath = "noimage.jpg";
                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
                photoService.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }

        }

        public ActionResult Edit(Guid id)
        {

            Photo photo = photoService.GetById(id);
            TempData["ImagePath"] = photo.ImagePath;
            return View(photo);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Photo photo, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (photo.ImagePath != null)
                    {
                        photoService.Update(photo);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), TempData["ImagePath"].ToString());
                    photo.ImagePath = TempData["ImagePath"].ToString();

                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    photo.ImagePath = image.FileName;
                }
                photoService.Update(photo);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }
        }



        public ActionResult Delete(Guid id)
        {
            return View(photoService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Photo photo)
        {
            try
            {
                photoService.Remove(photo.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
