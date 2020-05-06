using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fault Description")]
        public string FaultDescription { get; set; }

        [Display(Name = "Repair Description")]
        public string RepairDescription { get; set; }
        public string Note { get; set; }

        [Display(Name = "Start Time"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Completion Time"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime CompletionTime { get; set; }
        public Status Status { get; set; }

        // Navigational Properties

        [ForeignKey("Booking")]
        public string BookingId { get; set; }
        public Booking Booking { get; set; }

        [ForeignKey("Bike")]
        public string bikeId { get; set; }
        public Bike Bike { get; set; }

        public List<JobParts> JobParts { get; set; }
        public List<HoursWorked> HoursWorked { get; set; }
    }
}