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
        User GetUserById(int id);

        List<GrowableItem> GetAllGrowableItems();
        GrowableItem GetGrowableItemById(int id);

        List<Humidity> GetAllHumidity();
        Humidity GetHumidityById(int id);

        List<Light> GetAllLight();
        Light GetLightById(int id);

        List<Temperature> GetAllTemperature();
        Temperature GetTemperatureById(int id);
    }
}
