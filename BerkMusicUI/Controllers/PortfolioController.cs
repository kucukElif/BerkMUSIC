using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPhotoService photoService;
        private readonly IVideoService videoService;

        public PortfolioController(IPhotoService photoService,IVideoService videoService)
        {
            this.photoService = photoService;
            this.videoService = videoService;
        }
      
        public IActionResult Photos()
        {
            return View(photoService.GetActive());
        }
        public IActionResult Video()
        {
            return View(videoService.GetActive());
        }
    }
}
