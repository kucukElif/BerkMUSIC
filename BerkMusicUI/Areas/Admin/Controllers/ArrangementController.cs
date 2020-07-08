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
    public class ArrangementController : Controller
    {
        private readonly IArrangementService arrangementService;

        public ArrangementController(IArrangementService arrangementService)
        {
            this.arrangementService = arrangementService;
        }
        public IActionResult Index()
        {
            return View(arrangementService.GetActive());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Arrangement model, IFormFile image)
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
                arrangementService.Add(model);
                return RedirectToAction("Index");


            }
            catch
            {

                return View();
            }

        }

        public IActionResult Edit(Guid id)
        {
            Arrangement arrangement = arrangementService.GetById(id);
            return View(arrangement);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Arrangement arrangement, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (arrangement.ImagePath != null)
                    {
                        arrangementService.Update(arrangement);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "noimage.jpg");
                    arrangement.ImagePath = "noimage.jpg";

                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    arrangement.ImagePath = image.FileName;
                }
                arrangementService.Update(arrangement);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }

        }



        public ActionResult Delete(Guid id)
        {
            return View(arrangementService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Layout layout)
        {
            try
            {
                arrangementService.Remove(layout.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
