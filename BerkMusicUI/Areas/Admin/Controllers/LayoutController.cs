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
    public class LayoutController : Controller
    {
        private readonly ILayoutService layoutService;

        public LayoutController(ILayoutService layoutService)
        {
            this.layoutService = layoutService;
        }
        public IActionResult Index()
        {
            return View(layoutService.GetActive());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Layout model, IFormFile image)
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
                layoutService.Add(model);
                return RedirectToAction("Index");


            }
            catch
            {

                return View();
            }

        }

        public IActionResult Edit(Guid id)
        {
            Layout layout = layoutService.GetById(id);
            return View(layout);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Layout layout, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (layout.ImagePath != null)
                    {
                        layoutService.Update(layout);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "noimage.jpg");
                    layout.ImagePath = "noimage.jpg";

                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    layout.ImagePath = image.FileName;
                }
                layoutService.Update(layout);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }

        }



        public ActionResult Delete(Guid id)
        {
            return View(layoutService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Layout layout)
        {
            try
            {
                layoutService.Remove(layout.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
