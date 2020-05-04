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
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
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


                //  Create new Staff.
                UserManager<Staff> staffManager = new UserManager<Staff>(new UserStore<Staff>(context));

                // Assign Admin role.
                if (staffManager.FindByName("admin@cycletex.com") == null)
                {
                    staffManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var admin = new Staff()
                    {
                        UserName = "admin@cycletex.com",
                        Email = "admin@cycletex.com",
                        Name = "Adam Admin",
                        Address = "1 Admin Road",
                        PostCode = "ADMIN1",
                        DateOfBirth = new DateTime(1992, 12, 15),
                        JoinDate = DateTime.Now,
                        EndDate = new DateTime(),
                        Salary = 50000
                    };

                    staffManager.Create(admin, "1");
                    staffManager.AddToRole(admin.Id, "Admin");
                }
                context.SaveChanges();

                // Assign Workshop Manager role.
                if (staffManager.FindByName("workshopmanager@cycletex.com") == null)
                {
                    staffManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var workshopManager = new Staff()
                    {
                        UserName = "workshopmanager@cycletex.com",
                        Email = "workshopmanager@cycletex.com",
                        Name = "Workshop Wallace",
                        Address = "1 Workshop Road",
                        PostCode = "WRKSHP",
                        DateOfBirth = new DateTime(1982, 12, 15),
                        JoinDate = DateTime.Now,
                        EndDate = new DateTime(),
                        Salary = 30000
                    };

                    staffManager.Create(workshopManager, "1");
                    staffManager.AddToRole(workshopManager.Id, "Workshop Manager");
                }
                context.SaveChanges();

                // Assign Stock Manager role.
                if (staffManager.FindByName("stockmanager@cycletex.com") == null)
                {
                    staffManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var stockManager = new Staff()
                    {
                        UserName = "stockmanager@cycletex.com",
                        Email = "stockmanager@cycletex.com",
                        Name = "Stevie Stock",
                        Address = "1 Stock Road",
                        PostCode = "ST0CK1",
                        DateOfBirth = new DateTime(1972, 12, 15),
                        JoinDate = DateTime.Now,
                        EndDate = new DateTime(),
                        Salary = 30000
                    };

                    staffManager.Create(stockManager, "1");
                    staffManager.AddToRole(stockManager.Id, "Workshop Manager");
                }
                context.SaveChanges();

                // Assign Floor Staff role.
                if (staffManager.FindByName("floorstaff@cycletex.com") == null)
                {
                    staffManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var floorStaff = new Staff()
                    {
                        UserName = "floorstaff@cycletex.com",
                        Email = "floorstaff@cycletex.com",
                        Name = "Florence Floor",
                        Address = "1 Floor Road",
                        PostCode = "FL00R1",
                        DateOfBirth = new DateTime(1962, 12, 15),
                        JoinDate = DateTime.Now,
                        EndDate = new DateTime(),
                        Salary = 30000
                    };

                    staffManager.Create(floorStaff, "1");
                    staffManager.AddToRole(floorStaff.Id, "Floor Staff");
                }
                context.SaveChanges();

                // Assign Technician role.
                if (staffManager.FindByName("technician@cycletex.com") == null)
                {
                    staffManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var technician = new Staff()
                    {
                        UserName = "technician@cycletex.com",
                        Email = "technician@cycletex.com",
                        Name = "Tech Tam",
                        Address = "1 Techy Road",
                        PostCode = "T3CHN0",
                        DateOfBirth = new DateTime(1922, 12, 15),
                        JoinDate = DateTime.Now,
                        EndDate = new DateTime(),
                        Salary = 12000
                    };

                    staffManager.Create(technician, "1");
                    staffManager.AddToRole(technician.Id, "technician");
                }
                context.SaveChanges();

                //  Create new Customer.
                //UserManager<Staff> customerManager = new UserManager<Staff>(new UserStore<Staff>(context));
            }
        }
    }
}