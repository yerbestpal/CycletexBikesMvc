using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// JobParts class.
    /// Many to Many bridge class between Part and Job classes.
    /// </summary>
    public class JobParts
    {
        public int Quantity { get; set; }

        // Navigational Properties

        [ForeignKey("Part")]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey("Job")]
        public string JobId { get; set; }
        public Job Job { get; set; }
    }
}