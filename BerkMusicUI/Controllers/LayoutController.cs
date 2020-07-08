using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ILayoutService layoutService;
        private readonly IDrumService drumService;
        private readonly IArrangementService arrangementService;

        public LayoutController(ILayoutService layoutService, IDrumService drumService, IArrangementService arrangementService)
        {
            this.layoutService = layoutService;
            this.drumService = drumService;
            this.arrangementService = arrangementService;
        }
        public IActionResult Record()
        {
           
            return View(layoutService.GetActive());
        }
        public IActionResult Arrangement()
        {
            return View(arrangementService.GetActive());
        }
        public IActionResult DrumLesson()
        {
            return View(drumService.GetActive());
        }
    }
}
