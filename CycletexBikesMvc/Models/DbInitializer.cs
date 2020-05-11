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

            // Seed Services.
            #region SeedServices
            /* Originally, I planned to use just enums for Bike Services, until I realised that Services
               would require a price. I used the following code so the BikeServiceNames enum would not be
               redundant however it would have been more efficient and less time consuming to just seed the
               BikeService class without it.*/
            var serviceNames = Enum.GetValues(typeof(BikeServiceNames)).Cast<BikeServiceNames>();
            List<BikeService> services = new List<BikeService>();
            foreach (var service in serviceNames)
            {
                services.Add(new BikeService()
                {
                    Name = service.ToString()
                });
            }

            services[0].Cost = 10; services[1].Cost = 15; services[2].Cost = 10;
            services[3].Cost = 15; services[4].Cost = 20; services[5].Cost = 30;
            services[6].Cost = 8; services[7].Cost = 18; services[8].Cost = 6;
            services[9].Cost = 50; services[10].Cost = 55; services[11].Cost = 10;
            services[12].Cost = 12; services[13].Cost = 18; services[14].Cost = 10;
            services[15].Cost = 8; services[16].Cost = 20; services[17].Cost = 25;
            services[18].Cost = 15; services[19].Cost = 15; services[20].Cost = 8;
            services[21].Cost = 8; services[22].Cost = 8; services[23].Cost = 20;
            services[24].Cost = 6; services[25].Cost = 20; services[26].Cost = 5;
            services[27].Cost = 10; services[28].Cost = 8; services[29].Cost = 75;
            services[30].Cost = 25; services[31].Cost = 25;

            foreach (BikeService service in services)
            {
                context.BikeServices.Add(service);
            }

            context.SaveChanges();
            #endregion
        }
    }
}