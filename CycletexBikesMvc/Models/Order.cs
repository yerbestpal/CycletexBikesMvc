// name: Ross McLean
// date: 17/05/20

// name: Ross McLean
// date: 17/05/20

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Order POCO class
    /// Staff would have placed Orders for Parts to be fulfilled by the Supplier
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Arrival Date")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Has Arrived?")]
        public bool HasArrived { get; set; }

        // Navigational Properties

        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}