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
    public class DrumController : Controller
    {
        private readonly IDrumService drumService;

        public DrumController(IDrumService drumService)
        {
            this.drumService = drumService;
        }
        public IActionResult Index()
        {
            return View(drumService.GetActive());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrumLesson model, IFormFile image)
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
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
                drumService.Add(model);
                return RedirectToAction("Index");


            }
            catch
            {

                return View();
            }

        }

        public IActionResult Edit(Guid id)
        {
            DrumLesson drumLesson = drumService.GetById(id);
            return View(drumLesson);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DrumLesson drumLesson, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (drumLesson.ImagePath != null)
                    {
                        drumService.Update(drumLesson);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "noimage.jpg");
                    drumLesson.ImagePath = "noimage.jpg";

                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    drumLesson.ImagePath = image.FileName;
                }
                drumService.Update(drumLesson);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }

        }



        public ActionResult Delete(Guid id)
        {
            return View(drumService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DrumLesson drumLesson)
        {
            try
            {
                drumService.Remove(drumLesson.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
