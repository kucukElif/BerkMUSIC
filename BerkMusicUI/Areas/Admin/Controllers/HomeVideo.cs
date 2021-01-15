using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeVideo : Controller
    {
        private readonly IHomePageVideoService homePageVideoService;

        public HomeVideo(IHomePageVideoService homePageVideoService)
        {
            this.homePageVideoService = homePageVideoService;
        }
       
        public IActionResult Index()
        {
            return View(homePageVideoService.GetActive());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomePageVideo model)
        {
            if (model.VideoPath == null)
            {
                model.VideoPath = "novideo.png";


            }
            homePageVideoService.Add(model);
            return RedirectToAction("Index");


        }


        public IActionResult Delete(Guid id)
        {
            return View(homePageVideoService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Video video)
        {
            homePageVideoService.Remove(video.ID);
            return RedirectToAction("Index");
        }
    }
}
