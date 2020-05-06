using System;
using System.Collections.Generic;
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
        public DateTime Date { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public int CardSecurityNo { get; set; }
        public int Total { get; set; }

        // Navigational properties

        [ForeignKey("Category")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Job> Jobs { get; set; }
    }
}