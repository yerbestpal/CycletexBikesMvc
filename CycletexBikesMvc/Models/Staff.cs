using System;
using System.Collections.Generic;
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
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal Salary { get; set; }
    }
}