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
    /// JobService class
    /// Creates many to many relationship between Job and BikeService classes
    /// Before requirements changed, Jobs would have a BikeService, and a Booking
    /// would have many Jobs, thus this class would facilitate that
    /// </summary>
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