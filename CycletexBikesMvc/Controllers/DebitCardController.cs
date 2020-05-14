// name: Ross McLean
// date: 14/05/20

using CycletexBikesMvc.Extensions;
using CycletexBikesMvc.Models;
using CycletexBikesMvc.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    /// <summary>
    /// DebitCardController class
    /// Manages DebitCard functionality
    /// </summary>
    public class DebitCardController : Controller
    {
        /// <summary>
        /// Instance of the database.
        /// </summary>
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: DebitCard
        /// <summary>
        /// Get all DebitCards pertaining to an individual Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>ViewAllCustomersCards view</returns>
        [HttpGet]
        public ActionResult ViewAllCustomersCards(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id is null)
                        throw new ArgumentNullException(nameof(id));

                    List<DebitCard> AllCustomersCardsInDb = context.DebitCards.Where(d => d.CustomerId == id).ToList();

                    if (AllCustomersCardsInDb.Count() <= 0)
                    {
                        this.AddNotification("You have no cards", NotificationType.WARNING);
                        return View(AllCustomersCardsInDb);
                    }
                    return View(AllCustomersCardsInDb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: DebitCard/Create
        [HttpGet]
        public ActionResult Create(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (ModelState.IsValid)
            {
                try
                {
                    CreateDebitCardViewModel viewModel = new CreateDebitCardViewModel
                    {
                        CardHolderName = context.Users.Find(id).Name,
                        ExpiryDate = DateTime.Now
                    };
                    return View(viewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("ViewAllCustomersCards");
                }
            }
            return RedirectToAction("ViewAllCustomersCards");
        }

        // POST: DebitCard/Create
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

        // GET: DebitCard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DebitCard/Edit/5
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

        // GET: DebitCard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DebitCard/Delete/5
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

        /// <summary>
        /// MaskFirstTwelveCharacters method
        /// Masks the first twelve characters of a debit card number
        /// </summary>
        /// <param name="cardNumber">16-digit debit card number</param>
        /// <returns>16-char string</returns>
        // Unsure if ValidateAntiForgeryToken belongs here. I am placing it just in case,
        // since the method is called from a POST action after a form is sent
        [ValidateAntiForgeryToken]  
        public string MaskFirstTwelveCharacters(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return "NullValueError: contact administrator";
            if (cardNumber.Length < 16)
                return "Invalid Number: missing characters";

            string oldCardNo = cardNumber;
            string MaskedCardNo = oldCardNo.Replace(oldCardNo, "**** **** **** " + oldCardNo.Substring(11, 4));
            return MaskedCardNo;
        }
    }
}
