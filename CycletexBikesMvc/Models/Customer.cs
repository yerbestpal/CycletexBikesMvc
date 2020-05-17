// name: Ross McLean
// date: 17/05/20

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Customer POCO class
    /// Extends ApplicationUser class
    /// </summary>
    public class Customer : ApplicationUser
    {
        // No unique properties except for navigation properties.

        public List<Bike> Bikes { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<DebitCard> DebitCards { get; set; }
    }
}