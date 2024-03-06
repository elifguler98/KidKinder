using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {

            var satranc = context.Services.FirstOrDefault().Title;
            ViewBag.satranc = satranc;

            var sinifsayi = context.Services.Count().ToString();
            ViewBag.sinifsayi = sinifsayi;

            var ogrencisayi = context.BookASeats.Count().ToString();
            ViewBag.ogrencisayi = ogrencisayi;

            var sonogrenci = context.BookASeats.ToList().LastOrDefault().Name;
            ViewBag.sonogrenci = sonogrenci;

            var ogrtsayi = context.Teachers.Count().ToString();
            ViewBag.ogrt = ogrtsayi;

            var sinif = context.ClassRooms.Count().ToString();
            ViewBag.sinif = sinif;  

            return View();
        }

        public PartialViewResult _PartialTestimonial()
        {
            var deger = context.Testimonials.ToList();
            return PartialView(deger);
        }
    }
}