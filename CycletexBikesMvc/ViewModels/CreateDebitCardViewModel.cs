// name: Ross McLean
// date: 14/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.ViewModels
{
    /// <summary>
    /// CreateDebitCardViewModel class
    /// Creates a view for the DebitCard Create action
    /// </summary>
    public class CreateDebitCardViewModel
    {

        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

        [Display(Name = "Card Number"), MaxLength(16)]
        public string CardNumber { get; set; }

        [Display(Name = "3-Digit CVV2 Number"), MaxLength(3)]
        public string CVV2 { get; set; }

        //[Display(Name = "Expiry Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public string ExpiryDate { get; set; }
    }
}