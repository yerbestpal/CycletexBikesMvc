// name: Ross McLean
// date: 17/05/20

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
    /// OrderLine class
    /// Creates many to many relationship between Order and Part classes
    /// </summary>
    public class OrderLine
    {
        // Navigational Properties

        [Key, ForeignKey("Order"), Column(Order = 0)]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key, ForeignKey("Part"), Column(Order = 1)]
        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}