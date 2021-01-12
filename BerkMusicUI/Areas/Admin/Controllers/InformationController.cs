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
    public class InformationController : Controller
    {
        private readonly IInformationService informationService;

        public InformationController(IInformationService informationService)
        {
            this.informationService = informationService;
        }
        public IActionResult Index()
        {
            return View(informationService.GetActive());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Information model, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\noimage", "noimage.jpeg");
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
                informationService.Add(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Bir hata meydana geldi");
                return View(model);
            }
        }

        public IActionResult Edit(Guid id)
        {
            Information information = informationService.GetById(id);
            TempData["ImagePath"] = information.ImagePath;

            return View(information);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Information model, IFormFile image)
        {
            try
            {
                string path;
                if (image==null)
                {
                    if (model.ImagePath!=null)
                    {
                        informationService.Update(model);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), TempData["ImagePath"].ToString());
                    model.ImagePath = TempData["ImagePath"].ToString();
                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream =new FileStream(path,FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
                informationService.Update(model);
                return RedirectToAction("Index");
            }
            catch 
            {

                return View();
            }
        }

        public IActionResult Delete(Guid id)
        {
            return View(informationService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Information model)
        {
            try
            {
                informationService.Remove(model.ID);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }

        }


    }
}
