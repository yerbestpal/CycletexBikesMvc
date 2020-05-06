using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }

        [Display(Name = "Payment Date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Payment Type")]
        public PaymentTypes PaymentType { get; set; }
        public string Status { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Name On Card")]
        public string NameOnCard { get; set; }

        [Display(Name = "Security Code")]
        public string SecurityCode { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
    }
}