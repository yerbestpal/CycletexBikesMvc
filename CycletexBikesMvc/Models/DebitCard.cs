// name: Ross McLean
// date: 13/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// DebitCard POCO class
    /// Facilitates payment of bookings when required
    /// </summary>
    public class DebitCard
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Card Holder Name"), Required]
        public string CardHolderName { get; set; }

        [Display(Name = "Card Number"), MaxLength(16), Required]
        public string CardNumber { get; set; }

        [Display(Name = "3-Digit CVV2 Number"), MaxLength(3), Required]
        public string CVV2 { get; set; }

        [Display(Name = "Expiry Date"), DisplayFormat(DataFormatString = "{0:y}"), Required]
        public DateTime ExpiryDate { get; set; }

        // Navigational Properties.
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<Payment> Payments { get; set; }
    }
}