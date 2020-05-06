using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// OrderLine class.
    /// Many to Many bridge class between Part and Order classes.
    /// </summary>
    public class OrderLine
    {
        // Navigational Properties.

        [Key, ForeignKey("Order"), Column(Order = 0)]
        public string OrderId { get; set; }
        public Order Order { get; set; }

        [Key, ForeignKey("Part"), Column(Order = 1)]
        public string PartId { get; set; }
        public Part Part { get; set; }
    }
}