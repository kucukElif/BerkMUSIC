using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    public class VideoController : Controller
    {
      
        private readonly IVideoService videoService;

        public VideoController(IVideoService videoService)
        {
           
            this.videoService = videoService;
        }
        public IActionResult Index()
        {
            return View(videoService.GetActive());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Video model, IFormFile image)
        {
            try
            {
                string path;
                if (image == null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//noimage", "noimage.jpeg");
                    model.VideoPath = "noimage.jpg";
                }
                else
                {
                    path = Path.GetFullPath("wwwroot\\images\\" + image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.VideoPath = image.FileName;
                }
                videoService.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }

        }
    }
}  
