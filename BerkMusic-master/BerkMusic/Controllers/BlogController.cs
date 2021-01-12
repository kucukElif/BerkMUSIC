using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkMusic.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ViewResult Index()
        {
            return View();
        }
    }
}