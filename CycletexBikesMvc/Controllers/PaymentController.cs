// name: Ross McLean
// date: 15/05/20

using CycletexBikesMvc.Models;
using CycletexBikesMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                            Text = debitCardController.MaskFirstTwelveCharacters(card.CardNumber)
                        });
                    }

                    MakePaymentViewModel viewModel = new MakePaymentViewModel
                    {
                        DebitCards = debitCardsSelectList,
                        Total = booking.Total
                    };

                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " +ex.Message);
                    return RedirectToAction("", "", new { id = userId });
                }
            }
            return RedirectToAction("", "", new { id = userId });
        }

        // POST: Payment/MakePayment
        [HttpPost]
        //public ActionResult MakePayment(MakePaymentViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            return View();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}














        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
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

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
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

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
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
