using System;
using System.Collections.Generic;
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

        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Part")]
        public string PartId { get; set; }
        public Part Part { get; set; }
    }
}