using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Supplier class.
    /// Suppliers fulfil Part Orders for CycleTex.
    /// </summary>
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Website { get; set; }

        // Navigational Properties.

        public List<Order> Orders { get; set; }
    }
}