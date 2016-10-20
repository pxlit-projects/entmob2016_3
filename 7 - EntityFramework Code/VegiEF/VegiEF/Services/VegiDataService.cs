using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiEF.DataLayer;
using VegiEF.Model;

namespace VegiEF.Services
{
    class VegiDataService : IVegiDataService
    {
        public List<GrowableItem> GetAllGrowableItems()
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.GrowableItems
                             orderby g.GrowableItemID
                             select g).ToList();

                return query;
            }
        }

        public List<Humidity> GetAllHumidity()
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Humidity
                             orderby g.HumidityID
                             select g).ToList();

                return query;
            }
        }

        public List<Light> GetAllLight()
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Light
                             orderby g.LightID
                             select g).ToList();

                return query;
            }
        }

        public List<Temperature> GetAllTemperature()
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Temperature
                             orderby g.TemperatureID
                             select g).ToList();

                return query;
            }
        }

        public List<User> GetAllUsers()
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Users
                             orderby g.UserId
                             select g).ToList();

                return query;
            }
        }

        public GrowableItem GetGrowableItemById(int id)
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.GrowableItems
                            where g.GrowableItemID == id
                            orderby g.GrowableItemID
                            select g).FirstOrDefault();

                return query;
            }
        }

        public Humidity GetHumidityById(int id)
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Humidity
                             where g.HumidityID == id
                             orderby g.HumidityID
                             select g).FirstOrDefault();

                return query;
            }
        }

        public Light GetLightById(int id)
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Light
                             where g.LightID == id
                             orderby g.LightID
                             select g).FirstOrDefault();

                return query;
            }
        }

        public Temperature GetTemperatureById(int id)
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Temperature
                             where g.TemperatureID == id
                             orderby g.TemperatureID
                             select g).FirstOrDefault();

                return query;
            }
        }

        public User GetUserById(int id)
        {
            using (VegiContext db = new VegiContext())
            {

                var query = (from g in db.Users
                             where g.UserId == id
                             orderby g.UserId
                             select g).FirstOrDefault();

                return query;
            }
        }
    }
}
