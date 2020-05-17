// name: Ross McLean
// date: 12/05/20

using CycletexBikesMvc.Extensions;
using CycletexBikesMvc.Models;
using CycletexBikesMvc.ViewModels;
using Microsoft.AspNet.Identity;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// BookingController class
    /// Manages Booking functionality
    /// </summary>
    [Authorize]
    public class BookingController : Controller
    {
        /// <summary>
        /// Instance of the database.
        /// </summary>
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: Booking/Details/5
        /// <summary>
        /// Returns Booking Details view
        /// View displays a Bookings particular information
        /// </summary>
        /// <param name="id">Booking id</param>
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

                    // Success
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

            // Success
            return View(AllBookingsInDb);
        }

        /// <summary>
        /// Gets all Bookings pertaining to an individual Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>ViewAllCustomersBookings view</returns>
        public ActionResult ViewAllCustomersBookings(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id is null)
                        throw new ArgumentNullException(nameof(id));

                    List<Booking> AllCustomersBookingsInDb = context.Bookings.Where(b => b.CustomerId == id).ToList();

                    if (AllCustomersBookingsInDb.Count() <= 0)
                    {
                        this.AddNotification("You have made no bookings", NotificationType.WARNING);
                        return View(AllCustomersBookingsInDb);
                    }

                    // Success
                    return View(AllCustomersBookingsInDb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Creates selectLists from lists and sends those, and appropriate
        /// data to a new view model
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns>CreateBookingViewModel</returns>
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
                    List<Bike> bikes = context.Bikes.Where(b => b.CustomerId == id).ToList();
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
                        servicesSelectList.Add(new SelectListItem()
                        {
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

        /// <summary>
        /// Creates new booking from view model data and saves it to the database
        /// Sends SMS message to the Customer including information about their booking
        /// </summary>
        /// <param name="viewModel">CreateBookingViewModel</param>
        /// <returns>redirect to ViewAllCustomersBookings action</returns>
        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookingViewModel viewModel)
        {
            if (viewModel is null)
                throw new ArgumentNullException(nameof(viewModel));
            if (ModelState.IsValid)
            {
                try
                {
                    int BikeId = viewModel.SelectedBikeId;
                    string userId = User.Identity.GetUserId();

                    if (BikeId == 0)
                    {
                        this.AddNotification("Database error: Cannot find bike in system", NotificationType.ERROR);
                        return View();
                    }

                    // This is unlikely to trigger but here as a precaution
                    if (userId is null)
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

                    // Success
                    Booking NewBooking = new Booking()
                    {
                        Date = viewModel.Date,
                        CheckInDate = viewModel.Date.AddDays(2),
                        CheckOutDate = viewModel.Date.AddDays(3),
                        Total = 30,
                        BikeId = BikeId,
                        CustomerId = User.Identity.GetUserId(),
                        IsPaid = false
                    };

                    context.Bookings.Add(NewBooking);
                    context.SaveChanges();

                    Bike bike = context.Bikes.Find(BikeId);

                    // Twilio SMS notification
                    if (NewBooking != null)
                    {
                        SMSController SmsController = new SMSController();
                        SmsController.SendSms(
                            "+447722509271",
                            "Your " + bike.Brand.ToString() + " " +
                            bike.Model.ToString() + " is booked in for the date " +
                            NewBooking.Date
                        );
                    }

                    this.AddNotification("Successfully Booked", NotificationType.SUCCESS);
                    return RedirectToAction("ViewAllCustomersBookings", new { id = userId });
                }
                // TODO: return correct data to view
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return View();
                }
            }
            // TODO: return correct data to view
            return View();
        }

        /// <summary>
        /// Builds a PDF of all bookings in the system
        /// </summary>
        /// <returns>ActionAsPdf()</returns>
        public ActionResult AllBookingsToPdf()
        {
            // Must get cookies for session because ActionToPdf() creates a http request to load the page rather than printing the HTML directly.
            Dictionary<string, string> cookieCollection = new Dictionary<string, string>();
            foreach (var key in Request.Cookies.AllKeys)
            {
                cookieCollection.Add(key, Request.Cookies.Get(key).Value);
            }
            return new ActionAsPdf("ViewAllBookings")
            {
                FileName = "AllBookings.pdf",
                Cookies = cookieCollection
            };
        }
    }
}