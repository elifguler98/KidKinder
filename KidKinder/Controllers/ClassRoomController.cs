using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class ClassRoomController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ClassRoomList()
        {
            var values = context.ClassRooms.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateClassRoom()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateClassRoom(ClassRoom classRoom)
        {
            context.ClassRooms.Add(classRoom);
            context.SaveChanges();
            return RedirectToAction("ClassRoomList");
        }

        public ActionResult DeleteClassRoom(int id)
        {
            var value = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ClassRoomList");
        }

        [HttpGet]
        public ActionResult UpdateClassRoom(int id)
        {

            var value = context.ClassRooms.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateClassRoom(ClassRoom classRoom)
        {
            var value = context.ClassRooms.Find(classRoom.ClassRoomId);
            value.Title = classRoom.Title;
            value.Description = classRoom.Description;
            value.AgeofKids = classRoom.AgeofKids;
            value.TotalSeat = classRoom.TotalSeat;
            value.ClassTime = classRoom.ClassTime;
            value.Price = classRoom.Price;
            value.ImageUrl = classRoom.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ClassRoomList");
        }
    }
}