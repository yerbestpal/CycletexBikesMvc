using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Part class.
    /// Can be used by technicians to complete jobs.
    /// </summary>
    public class Part
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Colour { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required]
        public int ReOrderLevel { get; set; }

        [Required]
        public int ReOrderQuantity { get; set; }

        [Required]
        public int QuantityOnHand { get; set; }

        // Navigational Properties.

        public List<OrderLine> OrderLines { get; set; }

        public List<JobParts> JobParts { get; set; }
    }
}