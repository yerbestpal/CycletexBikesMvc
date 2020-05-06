using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    public class HoursWorked
    {
        public int Quantity { get; set; }

        // Navigational Properties

        [Key, ForeignKey("Job"), Column(Order = 0)]
        public int? JobId { get; set; }
        public Job Job { get; set; }

        [Key, ForeignKey("Labour"), Column(Order = 1)]
        public int LabourId { get; set; }
        public Labour Labour { get; set; }
    }
}