using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        KidKinderContext context = new KidKinderContext();
        public ActionResult GalleryList()
        {
            var values = context.Galleries.ToList();
            return View(values);
        }

        public ActionResult GalleryPassive(int id)
        {
            var values = context.Galleries.Find(id);

            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("GalleryList");

        }

        public ActionResult GalleryActive(int id)
        {
            var values = context.Galleries.Find(id);
            values.Status = true;
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

        [HttpGet]
        public ActionResult CreateGallery()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateGallery(Gallery p)
        {
            context.Galleries.Add(p);
            context.SaveChanges();
            return RedirectToAction("GalleryList");

        }

        public ActionResult DeleteGallery(int id)
        {
            var values = context.Galleries.Find(id);
            context.Galleries.Remove(values);
            context.SaveChanges();
            return RedirectToAction("GalleryList");

        }
       
    }
}