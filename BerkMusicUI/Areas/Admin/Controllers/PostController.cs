using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        public IActionResult Index()
        {
            return View(postService.GetActive());
        }

       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Post model, IFormFile image)
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
                    path = Path.Combine(Directory.GetCurrentDirectory(), image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    model.ImagePath = image.FileName;
                }
                    postService.Add(model);
                    return RedirectToAction("Index");

                
            }
            catch 
            {

                return View();
            }
            
            
            //if (ModelState.IsValid)
            //{
            //    postService.Add(model);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View();
            //}


        }

        public ActionResult Edit(Guid id)
        {

            Post post = postService.GetById(id);
            return View(post);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Post post, IFormFile image)
        {
            try
            {
                string path;
                if (image==null)
                {
                    if (post.ImagePath!=null)
                    {
                        postService.Update(post);
                        return RedirectToAction("Index");
                    }
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "noimage.jpg");
                    post.ImagePath = "noimage.jpg";

                }
                else
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), image.FileName);
                    using (var stream= new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    post.ImagePath = image.FileName;
                }
                postService.Update(post);
                return RedirectToAction("Index");

            }
            catch 
            {
                return View();

            }
            //if (ModelState.IsValid)
            //{
            //    postService.Update(post);
            //    return RedirectToAction("Index");

            //}
            //else
            //{
            //    return View();
            //}
        }

        public ActionResult Delete(Guid id)
        {
            return View(postService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Post post)
        {
            try
            {
                postService.Remove(post.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}