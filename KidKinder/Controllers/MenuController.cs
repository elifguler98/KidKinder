using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        KidKinderContext context = new KidKinderContext();
        public ActionResult GalleryIndex()
        {
            var values = context.Galleries.Where(x => x.Status == true).ToList();
            return View(values);
        }
        public ActionResult TeacherIndex()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }

        public ActionResult AboutIndex()
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

        public ActionResult ClassRoomIndex()
        {
            var values = context.ClassRooms.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult ContactIndex()
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

            return View();
        }


            [HttpPost]
        public ActionResult ContactIndexAdd(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}