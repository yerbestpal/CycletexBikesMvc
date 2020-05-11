using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Services class.
    /// Used to put BikeServices in the database with a price, 
    /// instead of just doing that in the first place.
    /// </summary>
    public class BikeService
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Cost { get; set; }

        // Navigational Properties.

        public List<JobServices> JobServices { get; set; }  // Many to many
    }
}