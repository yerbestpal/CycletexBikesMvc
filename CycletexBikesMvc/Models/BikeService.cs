﻿// name: Ross McLean
// date: 17/05/20

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// BikeService POCO class
    /// Stores names and prices for services to be performed on bikes
    /// This used to use an enumeration but after requirements were altered,
    /// I decided to give services a cost, and so refactored them to be stored
    /// in the database
    /// </summary>
    public class BikeService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }

        // Navigational Properties.

        public List<JobServices> JobServices { get; set; }
    }
}