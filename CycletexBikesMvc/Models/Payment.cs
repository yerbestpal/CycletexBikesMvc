using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Payment class.
    /// Facilitates payments for Bookings and Orders.
    /// </summary>
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public string Status { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string SecurityCode { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}