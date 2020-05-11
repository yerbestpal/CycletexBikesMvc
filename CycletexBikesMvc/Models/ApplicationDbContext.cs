using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Main DbContext class.
    /// Used to query database.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Adding tables to database

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Labour> Labour { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<BikeService> BikeServices { get; set; }
        public DbSet<HoursWorked> HoursWorked { get; set; }
        public DbSet<JobParts> JobParts { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public List<JobServices> JobServices { get; set; }




        /// <summary>
        /// Constructor.
        /// </summary>
        public ApplicationDbContext()
            : base("CycleTexConnection2", throwIfV1Schema: false)
        {
            // Drops and recreates database on application run.
            Database.SetInitializer(new DbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}