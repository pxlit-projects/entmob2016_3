using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSensDomain
{
    public class Humidity
    {
        private int humidityID;

        private double maxHumidity;
        private double minHumidity;

        public int HumidityId
        {
            get { return humidityID; }
            set { humidityID = value; }
        }

        public double MaxHumidity
        {
            get { return maxHumidity; }
            set { maxHumidity = value; }
        }

        public double MinHumidity
        {
            get { return minHumidity; }
            set { minHumidity = value; }
        }
    }
}
