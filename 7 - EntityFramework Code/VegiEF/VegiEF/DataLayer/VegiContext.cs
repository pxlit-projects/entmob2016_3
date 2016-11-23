using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiEF.Model;

namespace VegiEF.DataLayer
{
    class VegiContext : DbContext
    {
        public VegiContext() : base("VegiSensDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<GrowableItem> GrowableItems { get; set; }
        public DbSet<Humidity> Humidity { get; set; }
        public DbSet<Light> Light { get; set; }
        public DbSet<Temperature> Temperature { get; set; }

        //Fluent API (Powerpoint EF => slide 63+) (NEED 4)
        //Some Example: https://msdn.microsoft.com/en-us/data/jj591617(v=vs.113).aspx#1.1
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //1 - Set PrimaryKey
            modelBuilder.Entity<GrowableItem>().HasKey(g => g.GrowableItemID);

            //2 - Set Max lenght of a property
            modelBuilder.Entity<GrowableItem>().Property(g => g.Name).HasMaxLength(50);

            //3 - Make a property required
            modelBuilder.Entity<GrowableItem>().Property(g => g.Name).IsRequired();

            //4 - Set The collumn name of a property
            modelBuilder.Entity<GrowableItem>().Property(g => g.Name).HasColumnName("GrowableItemName");

            base.OnModelCreating(modelBuilder);
        }
    }
}
