using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;

namespace KidKinder.Controllers
{
    public class DefaultController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var bfoto = context.Abouts.FirstOrDefault().BigImageUrl;
            ViewBag.bfoto = bfoto;
            var header = context.Abouts.FirstOrDefault().Header;
            ViewBag.header = header;
            var title = context.Abouts.FirstOrDefault().Title;
            ViewBag.title = title;
            var description = context.Abouts.FirstOrDefault().Description;
            ViewBag.description = description;
            var sfoto = context.Abouts.FirstOrDefault().SmallImageUrl;
            ViewBag.sfoto = sfoto;
            var values = context.AboutLists.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialClassRooms()
        {
           
            var values = context.ClassRooms.OrderBy(x => x.ClassRoomId).Take(3).ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialBookASeat()
        {
            List<SelectListItem> siniflar = (from x in context.ClassRooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.Title,
                                           }).ToList();
            ViewBag.siniflar = siniflar;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialBookASeat(BookASeat bookASeat)
        {
            
          
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return PartialView("PartialBookASeat");
        }
        public PartialViewResult PartialTeacher()
        {
          
            var values = context.Teachers.ToList();
            
            return PartialView(values);
           
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter(MailSubscribe mailSubscribe)
        {
            var aciklama = context.Addresses.FirstOrDefault().Description;
            ViewBag.aciklama = aciklama;
            var adres = context.Addresses.FirstOrDefault().AddressDetail;
            ViewBag.adres = adres;
            var email = context.Addresses.FirstOrDefault().Email;
            ViewBag.email = email;
            var phone = context.Addresses.FirstOrDefault().Phone;
            ViewBag.phone = phone;
            var acilis = context.Addresses.FirstOrDefault().OpeningHours;
            ViewBag.acilis = acilis;

            context.MailSubscribes.Add(mailSubscribe);
            context.SaveChanges();

            return PartialView("PartialFooter");
            
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }

       


    }
}