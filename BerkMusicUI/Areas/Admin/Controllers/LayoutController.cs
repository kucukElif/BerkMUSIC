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
using BerkMusicUI.Areas.Admin.Models.ViewModels;
namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LayoutController : Controller
    {
        private readonly ILayoutService layoutService;
        private readonly IFullLayoutService fullLayoutService;

        public LayoutController(ILayoutService layoutService, IFullLayoutService fullLayoutService)
        {
            this.layoutService = layoutService;
            this.fullLayoutService = fullLayoutService;
        }



        public IActionResult Index()
        {
            return View(layoutService.GetActive());
        }


        public IActionResult FullLayout(Guid id, Guid layoutID)
        {
            LayoutVM layoutVM = new LayoutVM();
            layoutVM.Layout = layoutService.GetById(id);
            layoutVM.LayoutDetails = layoutService.GetLayoutDetails();
            layoutVM.FullLayouts = fullLayoutService.GetActive();

            return View(layoutVM);
        }
        public IActionResult CreateFullLayout()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFullLayout(FullLayout model, IFormFile image, Layout layout, Guid id)
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
                    //path = Path.Combine(Directory.GetCurrentDirectory(),  image.FileName);
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
                fullLayoutService.Add(model);
                var l = layoutService.GetById(id);
                var fl = fullLayoutService.GetById(model.ID);
                LayoutDetail ld = new LayoutDetail();

                ld.FullLayout = fl;
                ld.FullLayoutID = fl.ID;
                ld.Title = fl.Title;
                ld.Description = fl.Description;
                ld.ImagePath = fl.ImagePath;
                ld.Layout = l;
                ld.LayoutID = l.ID;
                layoutService.AddLayoutDestail(ld);
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                return View();
            }

        }
        public IActionResult EditFullLayout(Guid id)
        {
            FullLayout fullLayout = fullLayoutService.GetById(id);
            return View(fullLayout);
        }
        [HttpPost]
        public async Task<IActionResult> EditFullLayout(FullLayout model, IFormFile image, Guid id)
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
                    //path = Path.Combine(Directory.GetCurrentDirectory(),  image.FileName);
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
                fullLayoutService.Update(model);
           
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                return View();
            }
        }
        public ActionResult DeleteFullLayout(Guid id)
        {
            return View(fullLayoutService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFullLayout(FullLayout fullLayout)
        {
            try
            {
                fullLayoutService.Remove(fullLayout.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                    //path = Path.Combine(Directory.GetCurrentDirectory(),  image.FileName);
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

