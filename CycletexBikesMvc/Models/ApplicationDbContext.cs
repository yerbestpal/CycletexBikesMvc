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