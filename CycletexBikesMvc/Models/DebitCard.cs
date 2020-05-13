// name: Ross McLean
// date: 13/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// DebitCard class.
    /// Facilitates payment of bookings when required.
    /// </summary>
    public class DebitCard
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Card Expiry Date"),
         DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}"),
         DataType(DataType.DateTime)]
        public DateTime CardExpiryDate { get; set; }

        [Display(Name = "3-Digit CVV2 Number")]
        public int CVV2 { get; set; }

        [Display(Name = "Expiry Date"),
         DisplayFormat(DataFormatString = "{0:dd-MM}")]
        public DateTime ExpiryDate { get; set; }

        // Navigational Properties.
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<Payment> Payments { get; set; }
    }
}