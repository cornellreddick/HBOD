using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HBOD.Models;

namespace HBOD.DAL
{
    public class HBODContext : DbContext
    {
       public DbSet<Customer> Customers { get; set; }
       public DbSet<Hairstylist> Hairstylists { get; set; }
       public DbSet<Barber> Barbers { get; set; }
       public DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

