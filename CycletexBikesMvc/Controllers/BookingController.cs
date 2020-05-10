using CycletexBikesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CycletexBikesMvc.Controllers
{
    public class BookingController : Controller
    {
        //public ActionResult GetEvents(double start, double end)
        //{
        //    var fromDate = ConvertFromUnixTimestamp(start);
        //    var toDate = ConvertFromUnixTimestamp(end);

        //    //Get the events
        //    //You may get from the repository also
        //    var eventList = GetEvents();

        //    var rows = eventList.ToArray();
        //    return Json(rows, JsonRequestBehavior.AllowGet);
        //}

        //private List<Event> GetEvents()
        //{
        //    List<Event> eventList = new List<Event>();

        //    Event newEvent = new Event
        //    {
        //        Id = "1",
        //        Title = "Event 1",
        //        Start = DateTime.Now.AddDays(1).ToString("s"),
        //        End = DateTime.Now.AddDays(1).ToString("s"),
        //        AllDay = false
        //    };

        //    eventList.Add(newEvent);

        //    newEvent = new Event
        //    {
        //        Id = "1",
        //        Title = "Event 3",
        //        Start = DateTime.Now.AddDays(2).ToString("s"),
        //        End = DateTime.Now.AddDays(3).ToString("s"),
        //        AllDay = false
        //    };

        //    eventList.Add(newEvent);

        //    return eventList;
        //}

        //private static DateTime ConvertFromUnixTimestamp(double timestamp)
        //{
        //    var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //    return origin.AddSeconds(timestamp);
        //}




















        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
