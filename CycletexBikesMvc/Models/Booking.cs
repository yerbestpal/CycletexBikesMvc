using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Booking class.
    /// Books jobs to be performed on Customers bikes.
    /// </summary>
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Check-in Date")]
        public DateTime CheckInDate { get; set; }

        [Display(Name = "Check-out Date")]
        public DateTime CheckOutDate { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Card Expiry Date")]
        public DateTime CardExpiryDate { get; set; }

        [Display(Name = "3-Digit Security No.")]
        public int CardSecurityNo { get; set; }
        public int Total { get; set; }

        // Navigational properties

        [ForeignKey("Category")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Job> Jobs { get; set; }
    }
}