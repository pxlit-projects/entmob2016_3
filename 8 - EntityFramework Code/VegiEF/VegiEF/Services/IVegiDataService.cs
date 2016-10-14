using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiEF.Model;

namespace VegiEF.Services
{
    interface IVegiDataService
    {
        List<User> GetAllUsers();
        User GetSWMovieDetails(string uri);
        List<GrowableItem> GetAllGrowableItems();
        User GetAllGrowableItems(string uri);
        List<Humidity> GetAllHumidity();
        User GetAllHumidity(string uri);
        List<Light> GetAllLight();
        User GetAllLight(string uri);
        List<Temperature> GetAllTemperature();
        User GetAllTemperature(string uri);
    }
}
