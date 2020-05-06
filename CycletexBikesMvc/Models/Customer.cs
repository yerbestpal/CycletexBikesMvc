using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Main Customer class.
    /// Sets properties for Customer type.
    /// Extends ApplicationUser class.
    /// </summary>
    public class Customer : ApplicationUser
    {
        // No unique properties except for navigation properties.

        public List<Bike> Bikes { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}