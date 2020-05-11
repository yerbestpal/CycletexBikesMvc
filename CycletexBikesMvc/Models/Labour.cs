﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Labour class.
    /// Represents hours worked in a Job.
    /// </summary>
    public class Labour
    {
        [Key]
        public int Id { get; set; }
        public Decimal Cost { get; set; }
        public BikeServiceNames Service { get; set; }

        // Navigation Properties

        public List<HoursWorked> HoursWorked { get; set; }
    }
}