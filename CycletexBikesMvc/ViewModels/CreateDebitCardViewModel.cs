﻿// name: Ross McLean
// date: 14/05/20

using System.ComponentModel.DataAnnotations;

namespace CycletexBikesMvc.ViewModels
{
    /// <summary>
    /// CreateDebitCardViewModel class
    /// Creates a view for the DebitCard Create action
    /// </summary>
    public class CreateDebitCardViewModel
    {
        [Required]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

        [Required]
        [Display(Name = "Card Number"), MaxLength(16), MinLength(16)]
        [StringLength(16, ErrorMessage = "The {0} must be {2} characters long.", MinimumLength = 16)]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "3-Digit CVV2 Number"), MaxLength(3), MinLength(3)]
        [StringLength(3, ErrorMessage = "The {0} must be {2} characters long.", MinimumLength = 3)]
        public string CVV2 { get; set; }

        //[Display(Name = "Expiry Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public string ExpiryDate { get; set; }
    }
}