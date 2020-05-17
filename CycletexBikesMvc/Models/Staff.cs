// name: Ross McLean
// date: 17/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Staff POCO class
    /// Extends ApplicationUser class
    /// </summary>
    public class Staff : ApplicationUser
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Join Date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime JoinDate { get; set; }

        [Display(Name = "End Date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? EndDate { get; set; }

        [Required]
        public Decimal Salary { get; set; }

        // Navigational Properties.

        public List<Order> Orders { get; set; }
    }
}