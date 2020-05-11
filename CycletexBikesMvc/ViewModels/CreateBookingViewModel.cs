using CycletexBikesMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.ViewModels
{
    public class CreateBookingViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }

        public List<Bike> Bikes{ get; set; }

        public List<DebitCard> DebitCards { get; set; }

        public List<BikeService> Services { get; set; }
    }
}