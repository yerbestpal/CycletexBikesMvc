using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CycletexBikesMvc.ViewModels
{
    /// <summary>
    /// CreateBookingViewModel class
    /// Creates a view for the Booking Create action
    /// </summary>
    public class CreateBookingViewModel
    {
        // Initially I used the constructor to send +44 to the PhoneNumber textarea in the view,
        // however, I discovered that area codes are not necessary. Removing it allows me to set
        // the exact length of numbers to 11, and removes some responsibility from the user.

        //public CreateBookingViewModel()
        //{
        //    PhoneNumber = "+44";
        //}

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // Populates dropDownListFor()
        public List<SelectListItem> Bikes { get; set; }

        // Stores the Id of the selected item
        [Required]
        public int SelectedBikeId { get; set; }

        public List<SelectListItem> BikeServices { get; set; }
        
        [Required]
        public int BikeService { get; set; }

        public bool IsPaid { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be {2} characters long.", MinimumLength = 11)]
        public string PhoneNumber { get; set; }
    }
}