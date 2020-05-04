using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace CycletexBikesMvc.Models
{
    /// <summary>
    /// Main DbInitializer class.
    /// Seeds the various database tables with data for debugging.
    /// </summary>
    public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        /// <summary>
        /// Seeds the database
        /// </summary>
        /// <param name="context">Database instance</param>
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // Create roles.
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Workshop Manager"))
                {
                    roleManager.Create(new IdentityRole("Workshop Manager"));
                }

                if (!roleManager.RoleExists("Stock Manager"))
                {
                    roleManager.Create(new IdentityRole("Stock Manager"));
                }

                if (!roleManager.RoleExists("Floor Staff"))
                {
                    roleManager.Create(new IdentityRole("Floor Staff"));
                }

                if (!roleManager.RoleExists("Technician"))
                {
                    roleManager.Create(new IdentityRole("Technician"));
                }

                if (!roleManager.RoleExists("Customer"))
                {
                    roleManager.Create(new IdentityRole("Customer"));
                }

                context.SaveChanges();


                // Create Admin user.
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (userManager.FindByName("admin@cycletex.com") == null)
                {
                    userManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var admin = new ApplicationUser()
                    {
                        UserName = "admin@cycletex.com",
                        Email = "admin@cycletex.com",
                        Name = "Adam Admin",
                        
                    };
                }
            }
        }
    }
}