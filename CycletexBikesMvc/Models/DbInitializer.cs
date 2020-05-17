// name: Ross McLean
// date: 12/05/20

// note: There are a couple of different approaches to seeding used here. This is because I initially thought that
//       the first value being added to the database for every model was null, which I thought was being caused by
//       using GetRange() to add lists of items to the database. Turns out I just couldn't see the first number
//       because of the dark theme! At least it demonstrates different approaches.
//
// note2: In the future, I would not populate my lists for seeding with the objects immediately because it makes them
//        difficult to debug and is time consuming to refactor.

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                    CardHolderName = "Ross McLean",
                    CardNumber = "1111111111111111",
                    ExpiryDate = DateTime.Today.AddYears(2),
                    CVV2 = "375"
                },
                new DebitCard {
                    CardHolderName = "Neil Hunter",
                    CardNumber = "2222222222222222",
                    ExpiryDate = DateTime.Today.AddYears(1),
                    CVV2 = "076"
                },
                new DebitCard {
                    CardHolderName = "Daniel Cunningham",
                    CardNumber = "3333333333333333",
                    ExpiryDate = DateTime.Today.AddDays(2),
                    CVV2 = "997"
                },
                new DebitCard {
                    CardHolderName = "Bob Cobb",
                    CardNumber = "4444444444444444",
                    ExpiryDate = DateTime.Today.AddDays(100),
                    CVV2 = "113"
                }
            };

            // Create Bikes
            Bike bike1 = new Bike
            {
                BikeType = Enum.GetName(typeof(BikeTypes), 1),
                Brand = "SportX",
                Model = "Type 2",
                PurchaseDate = DateTime.Now.AddDays(-200)
            };

            Bike bike2 = new Bike
            {
                BikeType = Enum.GetName(typeof(BikeTypes), 2),
                Brand = "MegaBikes",
                Model = "Ergo",
                PurchaseDate = DateTime.Now.AddDays(-10)
            };

            Bike bike3 = new Bike
            {
                BikeType = Enum.GetName(typeof(BikeTypes), 3),
                Brand = "Eurotrail",
                Model = "Off-Road Pro",
                PurchaseDate = DateTime.Now.AddDays(-200)
            };

            Bike bike4 = new Bike
            {
                BikeType = Enum.GetName(typeof(BikeTypes), 4),
                Brand = "Evans",
                Model = "Roadster",
                PurchaseDate = DateTime.Now
            };

            Bike bike5 = new Bike
            {
                BikeType = Enum.GetName(typeof(BikeTypes), 5),
                Brand = "Acline",
                Model = "Global",
                PurchaseDate = DateTime.Now.AddDays(-150)
            };

            // To be used for seeding Customers
            // Placed here so that Bookings can
            // access them
            Customer customer1 = null;
            Customer customer2 = null;
            Customer customer3 = null;
            Customer customer4 = null;

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

                #endregion CreateRoles

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

                    customer1 = new Customer()
                    {
                        UserName = "custome1r@email.com",
                        Email = "customer1@email.com",
                        Name = "Customer Carl",
                        Bikes = new List<Bike> { bike1, bike2, bike3 },
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

                    customer2 = new Customer()
                    {
                        UserName = "customer2@email.com",
                        Email = "customer2@email.com",
                        Name = "Customer Carl",
                        Bikes = new List<Bike> { bike4, bike5 },
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

                    customer3 = new Customer()
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

                    customer4 = new Customer()
                    {
                        UserName = "customer4@email.com",
                        Email = "customer4@email.com",
                        Name = "Customer Kate"
                    };

                    customerManager.Create(customer4, "1");
                    customerManager.AddToRole(customer4.Id, "Customer");
                }
            }

            // Seed Bikes
            if (!context.Bikes.Any())
            {
                context.Bikes.Add(bike1);
                context.Bikes.Add(bike2);
                context.Bikes.Add(bike3);
                context.Bikes.Add(bike4);
                context.Bikes.Add(bike5);
            }

            // Seed CreditCards
            if (!context.DebitCards.Any())
                context.DebitCards.AddRange(cards);

            context.SaveChanges();

            // Create Services
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

            // Seed Services
            if (!context.BikeServices.Any())
                context.BikeServices.AddRange(services);

            context.SaveChanges();

            // Create Bookings
            DateTime placeholderDate = DateTime.Now;
            List<Booking> bookings = new List<Booking>();

            //var date = placeholderDate.AddDays(-20);
            //var checkinDate = placeholderDate.AddDays(-18);
            //var checkoutDate = placeholderDate.AddDays(-16);
            //var total = 30;
            //var bikeId = bike1.Id;
            //var debitCardId = cards[0].Id;
            //var customerId = new Customer() { Id = "2000" }.Id;

            //Booking b = new Booking
            //{
            //    Date = date,
            //    CheckInDate = checkinDate,
            //    CheckOutDate = checkoutDate,
            //    Total = total,
            //    BikeId = bikeId,
            //    DebitCardId = debitCardId,
            //    CustomerId = customerId
            //};

            //bookings.Add(b);

            bookings.Add(new Booking
            {
                Date = placeholderDate.AddDays(-20),
                CheckInDate = placeholderDate.AddDays(-18),
                CheckOutDate = placeholderDate.AddDays(-16),
                Total = 30,
                BikeId = bike1.Id,
                CustomerId = customer1.Id
            });
            bookings.Add(new Booking
            {
                Date = placeholderDate.AddDays(-20),
                CheckInDate = placeholderDate.AddDays(-18),
                CheckOutDate = placeholderDate.AddDays(-16),
                Total = 250,
                BikeId = bike2.Id,
                CustomerId = customer2.Id
            });
            bookings.Add(new Booking
            {
                Date = placeholderDate.AddDays(-200),
                CheckInDate = placeholderDate.AddDays(-180),
                CheckOutDate = placeholderDate.AddDays(-160),
                Total = 425,
                BikeId = bike3.Id,
                CustomerId = customer3.Id
            });
            bookings.Add(new Booking
            {
                Date = placeholderDate.AddDays(-8),
                CheckInDate = placeholderDate.AddDays(-6),
                CheckOutDate = placeholderDate.AddDays(-4),
                Total = 25,
                BikeId = bike4.Id,
                CustomerId = customer4.Id
            });
            bookings.Add(new Booking
            {
                Date = placeholderDate.AddDays(-360),
                CheckInDate = placeholderDate.AddDays(-358),
                CheckOutDate = placeholderDate.AddDays(-356),
                Total = 37,
                BikeId = bike5.Id,
                CustomerId = customer4.Id
            });

            //Seed Bookings
            if (!context.Bookings.Any())
                context.Bookings.AddRange(bookings);

            context.SaveChanges();
        }
    }
}