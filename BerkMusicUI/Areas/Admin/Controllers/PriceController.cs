using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class PriceController : Controller
    {
        private readonly IPriceService priceService;

        public PriceController(IPriceService priceService)
        {
            this.priceService = priceService;
        }
        public IActionResult Index()
        {
            return View(priceService.GetActive());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Price price)
        {
            priceService.Add(price);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {

            Price price = priceService.GetById(id);
            return View(price);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Price price)
        {
           
                priceService.Update(price);
                return RedirectToAction("Index");

           
        }


        public ActionResult Delete(Guid id)
        {
            return View(priceService.GetById(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Post post)
        {
            try
            {
                priceService.Remove(post.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }



}
