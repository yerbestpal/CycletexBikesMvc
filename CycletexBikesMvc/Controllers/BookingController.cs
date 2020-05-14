﻿// name: Ross McLean
// date: 12/05/20

using CycletexBikesMvc.Extensions;
using CycletexBikesMvc.Models;
using CycletexBikesMvc.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// BookingController class.
    /// Manages Booking functionality.
    /// </summary>
    public class BookingController : Controller
    {
        /// <summary>
        /// Instance of the database.
        /// </summary>
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: Booking/Details/5
        /// <summary>
        /// Returns view showing various details from individual bookings
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details view</returns>
        public ActionResult Details(int? id)
        {
            string LoggedInUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                try
                {
                    if (LoggedInUserId == null)
                        return RedirectToAction("Login", "Account");
                    if (id == null) 
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Booking booking = context.Bookings.Find(id);
                    if (booking == null)
                        return HttpNotFound();
                    return View(booking);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    this.AddNotification("Booking not found in database", NotificationType.ERROR);
                    if (User.IsInRole("Customer"))
                        return RedirectToAction("ViewAllCustomersBookings", new { id = LoggedInUserId });
                    else
                        return RedirectToAction("ViewAllBookings");
                }
            }
            this.AddNotification("Error: modelState is invalid", NotificationType.ERROR);
            if (User.IsInRole("Customer"))
                return RedirectToAction("ViewAllCustomersBookings", new { id = LoggedInUserId });
            else
                return RedirectToAction("ViewAllBookings");
        }

        /// <summary>
        /// Gets all Bookings from the database
        /// </summary>
        /// <returns>ViewAllBookings view</returns>
        public ActionResult ViewAllBookings()
        {
            List<Booking> AllBookingsInDb = context.Bookings.ToList<Booking>();

            if (AllBookingsInDb.Count() == 0)
            {
                this.AddNotification("No bookings present", NotificationType.WARNING);
                return View(AllBookingsInDb);
            }

            return View(AllBookingsInDb);
        }

        /// <summary>
        /// Gets all Bookings pertaining to an individual Customer
        /// </summary>
        /// <returns>ViewAllCustomersBookings view</returns>
        public ActionResult ViewAllCustomersBookings(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            List<Booking> AllCustomersBookingsInDb = context.Bookings.Where(b => b.CustomerId == id).ToList<Booking>();

            if (AllCustomersBookingsInDb.Count() == 0)
            {
                this.AddNotification("You have made no bookings", NotificationType.WARNING);
                return View(AllCustomersBookingsInDb);
            }

            return View(AllCustomersBookingsInDb);
        }

        // GET: Booking/Create
        [HttpGet]
        public ActionResult Create(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (ModelState.IsValid)
            {
                try
                {
                    string userId = User.Identity.GetUserId();
                    List<Bike> bikes = context.Bikes.Where(b => b.CustomerId == userId).ToList();
                    List<BikeService> services = context.BikeServices.ToList();

                    List<SelectListItem> bikesSelectList = new List<SelectListItem>();
                    foreach (Bike bike in bikes)
                    {
                        bikesSelectList.Add(new SelectListItem()
                        {
                            Value = bike.Id.ToString(),
                            Text = bike.Model
                        });
                    }

                    List<SelectListItem> servicesSelectList = new List<SelectListItem>();
                    foreach (BikeService service in services)
                    {
                        servicesSelectList.Add(new SelectListItem() { 
                            Value = service.Id.ToString(),
                            Text = service.Name
                        });
                    }

                    CreateBookingViewModel viewModel = new CreateBookingViewModel
                    {
                        Date = DateTime.Now.AddHours(2),  // Default value
                        Bikes = bikesSelectList,
                        BikeServices = servicesSelectList
                    };

                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookingViewModel viewModel)        
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Validation

                    int BikeId = viewModel.SelectedBikeId;
                    string userId = User.Identity.GetUserId();

                    if (BikeId == 0)
                    {
                        this.AddNotification("Database error: Cannot find bike in system", NotificationType.ERROR);
                        return View();
                    }

                    // This is unlikely to trigger but here as a precaution
                    if (userId == null)
                        return RedirectToAction("Login", "Account");

                    if (viewModel.Date < DateTime.Now)
                    {
                        this.AddNotification("Only a future date may be selected", NotificationType.ERROR);
                        // Redirect to the create action, passing the view method, so dropdownlists are populated with valid data
                        return RedirectToAction("Create", new { id = userId });
                    }

                    if (viewModel.Date < DateTime.Now.AddHours(2))
                    {
                        this.AddNotification("We request at least 2 hours before any booking", NotificationType.ERROR);
                        return RedirectToAction("Create", new { id = userId });
                    }

                    if (viewModel.Date > viewModel.Date.AddMonths(2))
                    {
                        this.AddNotification("You may only book 2 months in advance", NotificationType.ERROR);
                        return RedirectToAction("Create", new { id = userId });
                    }

                    List<Booking> bookingsInDatabase = context.Bookings.ToList<Booking>();
                    foreach (Booking existingBooking in bookingsInDatabase)
                    {
                        if (existingBooking.Date == viewModel.Date)
                        {
                            this.AddNotification("Date Unavailable", NotificationType.ERROR);
                            return RedirectToAction("Create", new { id = userId });
                        }

                        if (!(viewModel.Date < existingBooking.Date) && !(viewModel.Date > existingBooking.Date.AddMinutes(15)))
                        {
                            this.AddNotification("This time slot is already booked", NotificationType.ERROR);
                            return RedirectToAction("Create", new { id = userId });
                        }
                    }

                    // Success path
                    Booking NewBooking = new Booking()
                    {
                        Date = viewModel.Date,
                        CheckInDate = viewModel.Date.AddDays(2),
                        CheckOutDate = viewModel.Date.AddDays(3),
                        Total = 30,
                        BikeId = BikeId,
                        CustomerId = User.Identity.GetUserId()
                    };

                    context.Bookings.Add(NewBooking);
                    context.SaveChanges();
                    this.AddNotification("Successfully Booked", NotificationType.SUCCESS);
                    return RedirectToAction("ViewAllCustomersBookings", new { id = userId });
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return View();
                }
            }
            return View();
        }

        // The below code has been commented out as it is not used, and has been left in place as proof of understanding, or something.

        /*

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

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        */
    }
}
