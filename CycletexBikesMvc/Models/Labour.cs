// name: Ross McLean
// date: 17/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Labour POCO class
    /// Represents hours worked in a Job
    /// Labour would have represented the rate at which Technicians were paid
    /// </summary>
    public class Labour
    {
        [Key]
        public int Id { get; set; }
        public Decimal Cost { get; set; }

        // Navigation Properties

        public List<HoursWorked> HoursWorked { get; set; }
    }
}