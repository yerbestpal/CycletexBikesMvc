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
    [Authorize]
    public class DebitCardController : Controller
    {
        /// <summary>
        /// Instance of the database.
        /// </summary>
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: DebitCard
        /// <summary>
        /// Gets all DebitCards pertaining to an individual Customer
        /// </summary>
        /// <param name="id">Customer id</param>
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

                    // Success
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

        /// <summary>
        /// Creates new CreateDebitCardViewModel, assign default values
        /// and send to view
        /// </summary>
        /// <param name="id">Customer</param>
        /// <returns>Redirect to ViewAllCustomersCards action</returns>
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
                        ExpiryDate = DateTime.Now.ToString()
                    };

                    // Success
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

        /// <summary>
        /// Create new DebitCard with values from viewModel and
        /// add to database
        /// </summary>
        /// <param name="viewModel">CreateDebitCardViewModel</param>
        /// <returns>redirect to ViewAllCustomersCards action</returns>
        // POST: DebitCard/Create
        [HttpPost]
        public ActionResult Create(CreateDebitCardViewModel viewModel)
        {
            string userId = User.Identity.GetUserId();

            if (userId is null)
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                try
                {
                    // Success
                    DebitCard card = new DebitCard
                    {
                        CardHolderName = viewModel.CardHolderName,
                        CardNumber = viewModel.CardNumber,
                        CVV2 = viewModel.CVV2,
                        CustomerId = userId
                    };

                    // TODO - add card validation (is null?)

                    string fourDigitYear = "20" + viewModel.ExpiryDate.Substring(3, 2);

                    int year = int.Parse(fourDigitYear);
                    int month = int.Parse(viewModel.ExpiryDate.Substring(0, 2));
                    DateTime date = new DateTime(year, month, 1);
                    card.ExpiryDate = date;

                    context.DebitCards.Add(card);
                    context.SaveChanges();
                    this.AddNotification("Card Added", NotificationType.SUCCESS);
                    return RedirectToAction("ViewAllCustomersCards", new { id = userId });
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    this.AddNotification("Error: could not add card", NotificationType.ERROR);
                    return RedirectToAction("ViewAllCustomersCards", new { id = userId });
                }
            }
            return RedirectToAction("ViewAllCustomersCards", new { id = userId });
        }

        /// <summary>
        /// Masks the first twelve characters of a debit card number
        /// </summary>
        /// <param name="cardNumber">16-digit debit card number</param>
        /// <returns>16-char masked string</returns>
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

        // Unused generated CRUD methods below======================================

        //// GET: DebitCard/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DebitCard/Edit/5
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

        //// GET: DebitCard/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DebitCard/Delete/5
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
