using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    public class HoursWorked
    {
        public int Quantity { get; set; }

        // Navigational Properties

        [ForeignKey("Job")]
        public string JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("Labour")]
        public string LabourId { get; set; }
        public Job Labour { get; set; }
    }
}