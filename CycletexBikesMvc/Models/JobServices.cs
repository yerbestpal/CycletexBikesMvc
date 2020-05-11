using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    public class JobServices
    {
        [Key, ForeignKey("BikeService"), Column(Order = 0)]
        public int BikeServiceId { get; set; }
        public BikeService BikeService { get; set; }

        [Key, ForeignKey("Job"), Column(Order = 1)]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}