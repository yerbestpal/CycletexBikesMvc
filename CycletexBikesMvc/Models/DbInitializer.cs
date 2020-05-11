using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

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
            // Create DebitCards
            List<DebitCard> cards = new List<DebitCard>
            {
                new DebitCard {
                    CardNumber = "1111111111111111",
                    CardExpiryDate = DateTime.Today.AddDays(365*2),
                    CardSecurityNo = 123
                },
                new DebitCard {
                    CardNumber = "2222222222222222",
                    CardExpiryDate = DateTime.Today.AddDays(365),
                    CardSecurityNo = 123
                },
                new DebitCard {
                    CardNumber = "3333333333333333",
                    CardExpiryDate = DateTime.Today.AddDays(2),
                    CardSecurityNo = 123
                },
                new DebitCard {
                    CardNumber = "4444444444444444",
                    CardExpiryDate = DateTime.Today.AddDays(100),
                    CardSecurityNo = 123
                }
            };

            // Create Bikes
            List<Bike> bikes = new List<Bike>
            {
                new Bike
                {
                    BikeType = Enum.GetName(typeof(BikeTypes), 1),
                    Brand = "SportX",
                    Model = "Type 2",
                    PurchaseDate = DateTime.Now.AddDays(-200)
                },
                new Bike
                {
                    BikeType = Enum.GetName(typeof(BikeTypes), 2),
                    Brand = "MegaBikes",
                    Model = "Ergo",
                    PurchaseDate = DateTime.Now.AddDays(-10)
                },
                new Bike
                {
                    BikeType = Enum.GetName(typeof(BikeTypes), 3),
                    Brand = "Eurotrail",
                    Model = "Off-Road Pro",
                    PurchaseDate = DateTime.Now.AddDays(-200)
                },
                new Bike
                {
                    BikeType = Enum.GetName(typeof(BikeTypes), 4),
                    Brand = "Evans",
                    Model = "Roadster",
                    PurchaseDate = DateTime.Now
                },
                new Bike
                {
                    BikeType = Enum.GetName(typeof(BikeTypes), 5),
                    Brand = "Acline",
                    Model = "Global",
                    PurchaseDate = DateTime.Now.AddDays(-150)
                }
            };

            // Seed Users
            if (!context.Users.Any())
            {
                // Create roles.
                #region CreateRoles
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                if (!roleManager.RoleExists("Admin")) 
                    roleManager.Create(new IdentityRole("Admin"));
                if (!roleManager.RoleExists("Workshop Manager")) 
                    roleManager.Create(new IdentityRole("Workshop Manager"));
                if (!roleManager.RoleExists("Stock Manager")) 
                    roleManager.Create(new IdentityRole("Stock Manager"));
                if (!roleManager.RoleExists("Floor Staff")) 
                    roleManager.Create(new IdentityRole("Floor Staff"));
                if (!roleManager.RoleExists("Technician")) 
                    roleManager.Create(new IdentityRole("Technician"));
                if (!roleManager.RoleExists("Customer")) 
                    roleManager.Create(new IdentityRole("Customer"));
                #endregion

                context.SaveChanges();

                //  Create new Staff
                UserManager<Staff> staffManager = new UserManager<Staff>(new UserStore<Staff>(context));

                // Assign Admin role
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
                        //EndDate = new DateTime(),
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
                        //EndDate = new DateTime(),
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
                        //EndDate = new DateTime(),
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
                        //EndDate = new DateTime(),
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
                        //EndDate = new DateTime(),
                        Salary = 12000
                    };

                    staffManager.Create(technician, "1");
                    staffManager.AddToRole(technician.Id, "technician");
                }
                context.SaveChanges();

                //  Create new Customer.
                UserManager<Customer> customerManager = new UserManager<Customer>(new UserStore<Customer>(context));

                // Assign Customer role.
                if (customerManager.FindByName("customer1@email.com") == null)
                {
                    customerManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var customer1 = new Customer()
                    {
                        UserName = "custome1r@email.com",
                        Email = "customer1@email.com",
                        Name = "Customer Carl",
                        Bikes = bikes,
                        DebitCards = cards.GetRange(0, 2)
                    };

                    customerManager.Create(customer1, "1");
                    customerManager.AddToRole(customer1.Id, "Customer");
                }

                if (customerManager.FindByName("customer2@email.com") == null)
                {
                    customerManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var customer2 = new Customer()
                    {
                        UserName = "customer2@email.com",
                        Email = "customer2@email.com",
                        Name = "Customer Carl",
                        Bikes = bikes.GetRange(0, 3),
                        DebitCards = cards.GetRange(2, 2)
                    };

                    customerManager.Create(customer2, "1");
                    customerManager.AddToRole(customer2.Id, "Customer");
                }

                if (customerManager.FindByName("customer3@email.com") == null)
                {
                    customerManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var customer3 = new Customer()
                    {
                        UserName = "customer3@email.com",
                        Email = "customer3@email.com",
                        Name = "Customer Kate"
                    };

                    customerManager.Create(customer3, "1");
                    customerManager.AddToRole(customer3.Id, "Customer");
                }

                if (customerManager.FindByName("customer4@email.com") == null)
                {
                    customerManager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequiredLength = 1,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    };

                    var customer4 = new Customer()
                    {
                        UserName = "customer4@email.com",
                        Email = "customer4@email.com",
                        Name = "Customer Kate"
                    };

                    customerManager.Create(customer4, "1");
                    customerManager.AddToRole(customer4.Id, "Customer");
                }
            }

            // Seed CreditCards
            if (!context.DebitCards.Any())
                context.DebitCards.AddRange(cards);

            // Seed Bikes
            if (!context.Bikes.Any())
                context.Bikes.AddRange(bikes);

            context.SaveChanges();

            // Create Services.
            List<BikeService> services = new List<BikeService>
            {
                new BikeService
                {
                    Name = "Inner Tube Replacement",
                    Cost = 10
                },
                new BikeService
                {
                    Name = "Hub Service",
                    Cost = 15
                },
                new BikeService
                {
                    Name = "Wheel Truing (Subject to Assessment)",
                    Cost = 10
                },
                new BikeService
                {
                    Name = "Wheel Assembly Front (Fitting tube and tyre)",
                    Cost = 15
                },
                new BikeService
                {
                    Name = "Wheel Assembly Rear (Fitting tube, tyre and cassette)",
                    Cost = 20
                },
                new BikeService
                {
                    Name = "Wheel Build",
                    Cost = 30
                },
                new BikeService
                {
                    Name = "Freewheel or Cassette",
                    Cost = 8
                },
                new BikeService
                {
                    Name = "Spoke Replacement (1-5 Spoke)",
                    Cost = 18
                },
                new BikeService
                {
                    Name = "Slime Service",
                    Cost = 6
                },
                new BikeService
                {
                    Name = "Standard Tubeless Setup (Regular Sealant)",
                    Cost = 50
                },
                new BikeService
                {
                    Name = "Premium Tubeless Setup (Race Sealant)",
                    Cost = 55
                },
                new BikeService
                {
                    Name = "Standard Tubeless Top Up",
                    Cost = 10
                },
                new BikeService
                {
                    Name = "Premium Tubeless Top Up",
                    Cost = 12
                },
                new BikeService
                {
                    Name = "Gear Service",
                    Cost = 18
                },
                new BikeService
                {
                    Name = "Gear Shifter Replacement (Each)",
                    Cost = 10
                },
                new BikeService
                {
                    Name = "Chain fitting",
                    Cost = 8
                },
                new BikeService
                {
                    Name = "Drivetrain Clean",
                    Cost = 20
                },
                new BikeService
                {
                    Name = "Bottom Bracket Repalcement/Service",
                    Cost = 25
                },
                new BikeService
                {
                    Name = "Front/Rear Mech",
                    Cost = 15
                },
                new BikeService
                {
                    Name = "Crank Replacement",
                    Cost = 15
                },
                new BikeService
                {
                    Name = "Jocket Wheel Replacement (Excluding parts)",
                    Cost = 8
                },
                new BikeService
                {
                    Name = "Mech Hanger Fit",
                    Cost = 8
                },
                new BikeService
                {
                    Name = "L/H Crank Arm Replacement",
                    Cost = 8
                },
                new BikeService
                {
                    Name = "Brake Service - Caliper/V Brakes (Both brakes)",
                    Cost = 20
                },
                new BikeService
                {
                    Name = "Brake Lever Fit",
                    Cost = 9
                },
                new BikeService
                {
                    Name = "Brake Fitting Hub & Frame Mount",
                    Cost = 25
                },
                new BikeService
                {
                    Name = "Hydraulic Brake Bleed (Per Brake)",
                    Cost = 20
                },
                new BikeService
                {
                    Name = "Brake Pads/Blocks (Pair)",
                    Cost = 6
                },
                new BikeService
                {
                    Name = "Headset Replacement",
                    Cost = 20
                },
                new BikeService
                {
                    Name = "Handlebar Grips Replacement",
                    Cost = 5
                },
                new BikeService
                {
                    Name = "Handlebar Retaping - Road Bike",
                    Cost = 10
                },
                new BikeService
                {
                    Name = "Stem Replacement",
                    Cost = 8
                },
                new BikeService
                {
                    Name = "Comprehensive Fork Service",
                    Cost = 75
                },
                new BikeService
                {
                    Name = "Lower Leg Service - Basic",
                    Cost = 25
                },
                new BikeService
                {
                    Name = "Rear Can Service - Basic",
                    Cost = 25
                },

            };

            if (!context.BikeServices.Any())
                context.BikeServices.AddRange(services);
            
            context.SaveChanges();
        }
    }
}