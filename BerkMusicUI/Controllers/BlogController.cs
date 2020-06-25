using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BerkMusicUI.Controllers
{
    public class BlogController : Controller
    {

        private readonly IPostService postService;

        public BlogController(IPostService postService)
        {
            this.postService = postService;
        }
        public IActionResult Index()
        {
            var posts = postService.GetActive();
            return View(posts);
        }

        public IActionResult FullPost(Guid id)
        {
            return View(postService.GetById(id));
        }

       
    }
}

