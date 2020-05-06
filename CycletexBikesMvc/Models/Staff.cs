using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Main Staff class.
    /// Sets properties for all Staff types.
    /// Extends ApplicationUser class.
    /// </summary>
    public class Staff : ApplicationUser
    {
        public string Address { get; set; }
        public string PostCode { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public Decimal Salary { get; set; }

        // Navigational Properties.

        public List<Order> Orders { get; set; }
    }
}