using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Entity;
using VegiSens.domain;

namespace VegiSens.DAL
{
    public class VegiSensContext : DbContext
    {
        public DbSet<GrowableItem> GrowableItems { get; set; }
        public DbSet<Light> Light { get; set; }
        public DbSet<Temperature> Temperature { get; set; }
        public DbSet<Humidity> Humidity { get; set; }

        //public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=VegiSens.db");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Make Blog.Url required
        //    modelBuilder.Entity<Blog>()
        //        .Property(b => b.Url)
        //        .IsRequired();
        //}
    }
}
