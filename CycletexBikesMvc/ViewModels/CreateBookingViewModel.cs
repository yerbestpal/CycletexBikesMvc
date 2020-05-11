using CycletexBikesMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CycletexBikesMvc.ViewModels
{
    /// <summary>
    /// CreateBookingViewModel class
    /// Creates a view for the Booking Create action
    /// </summary>
    public class CreateBookingViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }

        public List<SelectListItem> Bikes { get; set; }  // Populates dropDownListFor()
        public int Bike { get; set; }  // Stores the Id of the selected item

        public List<SelectListItem> DebitCards { get; set; }
        public int DebitCard { get; set; }

        public List<SelectListItem> BikeServices { get; set; }
        public int BikeService { get; set; }
    }
}