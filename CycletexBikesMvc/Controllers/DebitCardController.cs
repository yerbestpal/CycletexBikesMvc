// name: Ross McLean
// date: 14/05/20

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CycletexBikesMvc.Controllers
{
    public class DebitCardController : Controller
    {
        // GET: DebitCard
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    throw;
                }
            }
        }

        // GET: DebitCard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DebitCard/Create
        public ActionResult Create()
        {
            return View();
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
