using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
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
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Video model)
        {
            if (model.VideoPath == null)
            {
                model.VideoPath = "novideo.png";


            }
            videoService.Add(model);
                return RedirectToAction("Index");
           

        }


        public IActionResult Edit(Guid id)
        {
            Video video = videoService.GetById(id);
            
                TempData["VideoPath"] = video.VideoPath;

            
            return View(video);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Video video)
        {
            try
            {
                if (video.VideoPath == null)
                {
                    if (video.VideoPath != null)
                    {
                        videoService.Update(video);
                        return RedirectToAction("Index");
                    }
                    video.VideoPath = TempData["VideoPath"].ToString();

                }
              
                videoService.Update(video);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }
        }

        public IActionResult Delete(Guid id)
        {
            return View(videoService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Video video)
        {
            videoService.Remove(video.ID);
            return RedirectToAction("Index");
        }
    }
}  
