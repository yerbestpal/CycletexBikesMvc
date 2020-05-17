// name: Ross McLean
// date: 17/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Part POCO class
    /// Would be used by technicians to complete Jobs when required
    /// </summary>
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Colour { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required, Display(Name = "Re-Order Level")]
        public int ReOrderLevel { get; set; }

        [Required, Display(Name = "Re-Order Quantity")]
        public int ReOrderQuantity { get; set; }

        [Required, Display(Name = "Quantity On Hand")]
        public int QuantityOnHand { get; set; }

        // Navigational Properties

        public List<OrderLine> OrderLines { get; set; }

        public List<JobParts> JobParts { get; set; }
    }
}