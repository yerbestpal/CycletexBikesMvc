using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

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
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        [ForeignKey("Bike")]
        public int bikeId { get; set; }
        public Bike Bike { get; set; }

        public List<JobParts> JobParts { get; set; }  // Many to many
        public List<HoursWorked> HoursWorked { get; set; }
        public List<JobServices> JobServices { get; set; }  // Many to many
    }
}