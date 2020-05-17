// name: Ross McLean
// date: 17/05/20

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Supplier POCO class
    /// Suppliers fulfil Part Orders
    /// </summary>
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        public string Website { get; set; }

        // Navigational Properties

        public List<Order> Orders { get; set; }
    }
}