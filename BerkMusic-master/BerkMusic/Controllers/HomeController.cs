using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkMusic.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult HomePage()
        {
            return View();
        }
        public ViewResult Comment()
        {
            return View();
        }
      
    }
}