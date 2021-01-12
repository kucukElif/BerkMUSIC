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
    public class ReferanceController : Controller
    {
        private readonly IReferanceService referanceService;

        public ReferanceController(IReferanceService referanceService)
        {
            this.referanceService = referanceService;
        }
        public IActionResult Index()
        {
            return View(referanceService.GetActive()) ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Referance model, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", "noimage.jpg");
                    model.Photo = "noimage.jpg";
                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.Photo = image.FileName;
                }
                referanceService.Add(model);
                return RedirectToAction("Index");


            }
            catch
            {

                return View();
            }

        }
        public IActionResult Edit(Guid id)
        {
            Referance referance = referanceService.GetById(id);
            TempData["ImagePath"] = referance.Photo;
            return View(referance);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Referance referance, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    if (referance.Photo != null)
                    {
                        referanceService.Update(referance);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), TempData["ImagePath"].ToString());
                    referance.Photo = TempData["ImagePath"].ToString();

                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    referance.Photo = image.FileName;
                }
                referanceService.Update(referance);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }
        }

        public IActionResult Delete(Guid id)
        {
            return View(referanceService.GetById(id));
        }
        [HttpPost]
        public  IActionResult Delete(Referance referance)
        {
            referanceService.Remove(referance.ID);
            return RedirectToAction("Index");
        }
        }
}
