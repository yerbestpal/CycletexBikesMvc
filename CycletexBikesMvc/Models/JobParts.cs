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
    /// JobParts class
    ///  Creates many to many relationship between Job and Part classes
    /// </summary>
    public class JobParts
    {
        public int Quantity { get; set; }

        // Navigational Properties

        [Key, ForeignKey("Part"), Column(Order = 0)]
        public int PartId { get; set; }
        public Part Part { get; set; }

        [Key, ForeignKey("Job"), Column(Order = 1)]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}