using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    public class PaymentType
    {
        public PaymentTypes Type { get; set; }
    }

    public enum PaymentTypes
    {
        DebitCard,
        PayPal
    }

    // Insert nav properties.
}