using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Order class.
    /// Staff place Orders that are fulfilled by the Supplier.
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool HasArrived { get; set; }

        // Navigational Properties

        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}