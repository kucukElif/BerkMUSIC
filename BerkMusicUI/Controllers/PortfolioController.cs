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

        public PortfolioController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Photos()
        {
            return View(photoService.GetActive());
        } 
    }
}
