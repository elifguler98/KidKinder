using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class BookASeatController : Controller
    {
        // GET: BookASeat
        KidKinderContext context = new KidKinderContext();
        public ActionResult BookASeatList()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }
        public ActionResult DeleteBookASeat(int id)
        {
            var value = context.BookASeats.Find(id);
            context.BookASeats.Remove(value);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
    }
}