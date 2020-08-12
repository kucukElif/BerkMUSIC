using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FullPostController : Controller
    {
        private readonly IFullLayoutService fullLayoutService;
        private readonly ILayoutService layoutService;

        public FullPostController(IFullLayoutService fullLayoutService,ILayoutService layoutService)
        {
            this.fullLayoutService = fullLayoutService;
            this.layoutService = layoutService;
        }
        public IActionResult Index()
        {
            return View(fullLayoutService.GetActive());
        }

        public IActionResult CreateFullLayout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFullLayout(FullLayout model, Layout layout, LayoutDetail ld, IFormFile image)
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

                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                return View();
            }

        }
    }
}
