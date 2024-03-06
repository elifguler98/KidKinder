using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ChartController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            ViewBag.Resimler = context.Galleries.Count();
            ViewBag.Veliler = context.Testimonials.Count();
            ViewBag.Ogretmenler = context.Teachers.Count();
            ViewBag.Ogrenciler = context.BookASeats.Count();
            ViewBag.Siniflar = context.ClassRooms.Count();
          
            return View();
        }
    }
}