﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BerkMusicUI.Models;
using BerkMusicUI.Models;
using BLL.Abstract;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BerkMusicUI.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IIdentityService identityService;
        private readonly INavbarService navbarService;
        private readonly ILayoutService layoutService;
        private readonly IPriceService priceService;

        public HomeController( IIdentityService identityService, INavbarService navbarService, ILayoutService layoutService, IPriceService priceService)
        {
           
            this.identityService = identityService;
            this.navbarService = navbarService;
            this.layoutService = layoutService;
            this.priceService = priceService;
        }
        public IActionResult Index()
        {
            HomePageVM homePageVM = new HomePageVM();
            homePageVM.Identities = identityService.GetActive();
            homePageVM.NavbarItems = navbarService.GetActive();
            homePageVM.Layouts = layoutService.GetActive();
            return View(homePageVM);
        }

        public IActionResult FullLayout(Guid id)
        {
            FullLayoutVM fullLayoutVM = new FullLayoutVM();
            fullLayoutVM.Layout = layoutService.GetById(id);
            fullLayoutVM.LayoutDetails = layoutService.GetLayoutDetails();
            return View(fullLayoutVM);
            
        }

        public IActionResult PriceList()
        {
            return View(priceService.GetActive());
        }
            public IActionResult Contact()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Contact(Mail mail)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("elberkmusic@gmail.com", "*");
                client.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(mail.Email, " " + mail.Name+" "+mail.PhoneNumber);
                msg.To.Add("elberkmusic@gmail.com");
                msg.Subject = mail.Subject + " " + mail.Email;
                msg.Body = mail.Message;
              
                client.Send(msg);
                MailMessage msg1 = new MailMessage();
                msg1.From = new MailAddress("elberkmusic@gmail.com", "ElBerk Music");
                msg1.To.Add(mail.Email);
                msg1.Subject = "ElBerk Müzik Mail'inize Cevap";
                msg1.Body = ("Teşekkürler mail'iniz bize ulaştı size en kısa sürede dönüş yapacağız.");
                client.Send(msg1);
                ViewBag.Success = "Teşekkürler Mail Başarılı Bir Şekilde Gönderildi";
                return RedirectToAction("Success");

            }
            catch (Exception)
            {

                ViewBag.Error = "Mesaj Gönderilirken Bir Hata Oluştu!";
                return View();
            }
        }

        public IActionResult Success()
        {
            return View();
        }
       

      public IActionResult AboutUs()
        {
            return View();
        }
       
    }
}

