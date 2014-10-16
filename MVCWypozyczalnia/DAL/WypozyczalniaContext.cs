using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVCWypozyczalnia.Models;

namespace MVCWypozyczalnia.DAL
{
    public class WypozyczalniaContext : DbContext 
    {
        public WypozyczalniaContext()
            : base("WypozyczalniaContext")
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Rental> Rental { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}