using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Bike class.
    /// Represents Customers bikes used for bookings.
    /// </summary>
    public class Bike
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Bike Type")]
        public BikeTypes BikeType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }

        // Navigational properties

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Job> Jobs { get; set; }
    }
}