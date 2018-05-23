namespace HBOD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using HBOD.Models;

   
    
    internal sealed class Configuration : DbMigrationsConfiguration<HBOD.DAL.HBODContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HBOD.DAL.HBODContext context)
        {
            var customers = new List<Customer>
           {
               new Customer {CustomerID=0,FirstName= "Cornell", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="cornellreddick@yahoo.com",PostalCode="28390", PhoneNumber="3128335262" },
               new Customer {CustomerID=1,FirstName= "Mauric", LastName="Reddick", Address="5122 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="cornell@yahoo.com",PostalCode="28390", PhoneNumber="3128335262" },
               new Customer {CustomerID=2,FirstName= "Tasha", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="cornick@yahoo.com",PostalCode="28530", PhoneNumber="3128335262" },
               new Customer {CustomerID=3,FirstName= "Samuel", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="ick@yahoo.com",PostalCode="28370", PhoneNumber="3128335262" },
               new Customer {CustomerID=4,FirstName= "Ellona", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="red@yahoo.com",PostalCode="24390", PhoneNumber="3128335262" }
           };
            customers.ForEach(c => context.Customers.AddOrUpdate(p => p.CustomerID, c));
            context.SaveChanges();
            var babers = new List<Barber>
            {
               new Barber {BarberID=0,FirstName= "Mary", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="cornellreddick@yahoo.com",PostalCode="28390", PhoneNumber="3128335262" },
               new Barber {BarberID=1,FirstName= "Tina", LastName="Reddick", Address="5122 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="cornell@yahoo.com",PostalCode="28390", PhoneNumber="3128335262" },
               new Barber {BarberID=2,FirstName= "Corey", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="cornick@yahoo.com",PostalCode="28530", PhoneNumber="3128335262" },
               new Barber {BarberID=3,FirstName= "Fay", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="ick@yahoo.com",PostalCode="28370", PhoneNumber="3128335262" },
               new Barber {BarberID=4,FirstName= "Annatte", LastName="Reddick", Address="1431 Micah's Way North",
                   City ="Spring Lake", State="NC", Email="red@yahoo.com",PostalCode="24390", PhoneNumber="3128335262" }
            };
            babers.ForEach(b => context.Barbers.AddOrUpdate(p => p.BarberID, b));
            context.SaveChanges();

            var hairstylists = new List<Hairstylist>
            {
                new Hairstylist {HairstylistID = 0, FirstName ="Latrice", LastName= "Johnosn", Address="777 lane",
                    City ="Chicago", State="Ill",Email="latricejohnson@gmail.com", PostalCode="29384",PhoneNumber="45999660987"},
                new Hairstylist {HairstylistID = 1, FirstName ="Latoshia", LastName= "Yun", Address="776 lane",
                    City ="Chicago", State="Ill",Email="latricejohnson@gmail.com", PostalCode="29304",PhoneNumber="98588494"},
                new Hairstylist {HairstylistID = 2, FirstName ="Mike", LastName= "James", Address="757 lane",
                    City ="Chicago", State="Ill",Email="latricejohnson@gmail.com", PostalCode="29884",PhoneNumber="847378383"},
                new Hairstylist {HairstylistID = 3, FirstName ="Lee", LastName= "Williams", Address="277 lane",
                    City ="Chicago", State="Ill",Email="latricejohnson@gmail.com", PostalCode="29784",PhoneNumber="43544545"},
                new Hairstylist {HairstylistID = 4, FirstName ="Scottee", LastName= "Pippen", Address="747 lane",
                    City ="Chicago", State="Ill",Email="latricejohnson@gmail.com", PostalCode="29284",PhoneNumber="7954333556"},
            };
            hairstylists.ForEach(h => context.Hairstylists.AddOrUpdate(p => p.HairstylistID));
            context.SaveChanges();

            var registration = new List<Registration>
            {
                new Registration
                {
                    CustomerID = customers.Single(c => c.FirstName == "Cornell").CustomerID,
                    BarberID = babers.Single(c => c.BarberID == 0).BarberID, 
                    HairstylistID = hairstylists.Single(c => c.LastName == "Pippen").HairstylistID,
                },
                new Registration
                {
                    CustomerID = customers.Single(c => c.FirstName == "Lee").CustomerID,
                    BarberID = babers.Single(c => c.BarberID == 3).BarberID,
                    HairstylistID = hairstylists.Single(c => c.LastName == "Williams").HairstylistID,
                }, 
                new Registration
                {
                    CustomerID = customers.Single(c => c.FirstName == "Tasha").CustomerID,
                    BarberID = babers.Single(c => c.BarberID == 4).BarberID,
                    HairstylistID = hairstylists.Single(c => c.LastName == "Johnson").HairstylistID,
                }
            };

            foreach (Registration r in registration)
            {
                var registratonInDataBase = context.Registration.Where(
                    c => c.Customer.CustomerID == r.CustomerID &&
                         c.Barber.BarberID == r.BarberID &&
                         c.HairstylistID == r.HairstylistID).SingleOrDefault();
                if (registratonInDataBase == null)
                {
                    context.Registration.Add(r);
                }
                context.SaveChanges();
            };
        }
    }
}
