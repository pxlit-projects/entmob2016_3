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
        public VegiContext() : base("VegiDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<GrowableItem> GrowableItems { get; set; }
        public DbSet<Humidity> Humiditys { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
    }

    //public class StarWarsContext : DbContext
    //{
    //    public StarWarsContext() : base("StarWarsDB")
    //    {

    //    }
    //    public DbSet<SWMovie> SWMovies { get; set; }
    //    public DbSet<SWPlanet> SWPlanets { get; set; }
    //}
}
