﻿// name: Ross McLean
// date: 15/05/20

using CycletexBikesMvc.Extensions;
using CycletexBikesMvc.Models;
using CycletexBikesMvc.ViewModels;
using Microsoft.AspNet.Identity;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// PaymentController
    /// Manages Payment functionality
    /// </summary>
    public class PaymentController : Controller
    {
        /// <summary>
        /// Instance of the database.
        /// </summary>
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        /// <summary>
        /// Creates the MakePayment view by building a view model and populating it with required data
        /// </summary>
        /// <param name="userId">Customer id</param>
        /// <param name="bookingId">Booking id</param>
        /// <returns>MakePaymentViewModel</returns>
        // GET: Payment/MakePayment
        [HttpGet]
        public ActionResult MakePayment(string userId, int bookingId)
        {
            if (userId is null)
                throw new ArgumentNullException(nameof(userId));
            if (bookingId <= 0)
                return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = userId });
            if (ModelState.IsValid)
            {
                try
                {
                    List<DebitCard> debitCards = context.DebitCards.Where(d => d.CustomerId == userId).ToList();
                    List<SelectListItem> debitCardsSelectList = new List<SelectListItem>();
                    Booking booking = context.Bookings.Find(bookingId);
                    DebitCardController debitCardController = new DebitCardController();

                    foreach (DebitCard card in debitCards)
                    {
                        debitCardsSelectList.Add(new SelectListItem()
                        {
                            Value = card.Id.ToString(),
                            Text = debitCardController.MaskFirstTwelveCharacters(card.CardNumber)  // Masking card number
                        });
                    }

                    MakePaymentViewModel viewModel = new MakePaymentViewModel
                    {
                        DebitCards = debitCardsSelectList,
                        BookingId = booking.Id,
                        Total = booking.Total
                    };

                    // Success
                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = userId });
                }
            }
            return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = userId });
        }

        /// <summary>
        /// Creates new Payment and adds it to the database
        /// Marks the Booking as paid
        /// </summary>
        /// <param name="viewModel">MakePaymentViewModel</param>
        /// <returns>Redirect to ViewAllCustomersBookings action</returns>
        // POST: Payment/MakePayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePayment(MakePaymentViewModel viewModel)
        {
            if (viewModel is null)
                throw new ArgumentNullException(nameof(viewModel));
            if (ModelState.IsValid)
            {
                try
                {
                    DebitCard card = context.DebitCards.Find(viewModel.SelectedDebitCardId);
                    Booking booking = context.Bookings.Find(viewModel.BookingId);
                    if (card is null || booking is null)
                    {
                        this.AddNotification("Error: card cannot be found in database", NotificationType.ERROR);
                        return RedirectToAction("MakePayment", new { userId = User.Identity.GetUserId(), bookingId = viewModel.BookingId });
                    }

                    Payment payment = new Payment
                    {
                        Date = DateTime.Now,
                        Total = booking.Total,
                        IsSuccessful = true,
                        BookingId = booking.Id,
                        Booking = booking
                    };

                    if (payment is null)
                    {
                        this.AddNotification("Error: could not accept payment", NotificationType.ERROR);
                        return RedirectToAction("MakePayment", new { userId = User.Identity.GetUserId(), bookingId = viewModel.BookingId });
                    }

                    // Success
                    context.Bookings.Find(viewModel.BookingId).IsPaid = true;
                    context.Payments.Add(payment);
                    context.SaveChanges();
                    return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = User.Identity.GetUserId() });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("MakePayment", new { userId = User.Identity.GetUserId(), bookingId = viewModel.BookingId });
                }
            }
            return RedirectToAction("MakePayment", new { userId = User.Identity.GetUserId(), bookingId = viewModel.BookingId });
        }

        /// <summary>
        /// Gets the Booking Details view
        /// </summary>
        /// <param name="id">Booking id</param>
        /// <returns></returns>
        // GET: Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id is null)
                        throw new ArgumentNullException(nameof(id));
                    Payment payment = context.Payments.Find(id);
                    if (payment is null)
                        return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = User.Identity.GetUserId() });

                    // Success
                    return View(payment);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = User.Identity.GetUserId() });
                }
            }

            return RedirectToAction("ViewAllCustomersBookings", "Booking", new { id = User.Identity.GetUserId() });
        }

        /// <summary>
        /// Exports action to PDF view using Rotativa
        /// </summary>
        /// <returns>ActionAsPdf()</returns>
        public ActionResult PrintPaymentDetails(int id)
        {
            var page = new ActionAsPdf("Details", new { id = id });
            return page;
        }

        // Unused generated CRUD methods below======================================

        //// GET: Payment
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Payment/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Payment/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Payment/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Payment/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Payment/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Payment/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}