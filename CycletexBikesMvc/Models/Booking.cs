// name: Ross McLean
// date: 13/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

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

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Check-in Date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Check-out Date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime CheckOutDate { get; set; }

        public decimal Total { get; set; }

        // Navigational properties

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Bike")]
        public int BikeId { get; set; }
        public Bike Bike { get; set; }

        public List<Job> Jobs { get; set; }
    }
}