using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSensDomain
{
    public class Temperature
    {
        private int temperatureID;

        private double maxTemperature;
        private double minTemperature;

        public int TemperatureId
        {
            get { return temperatureID; }
            set { temperatureID = value; }
        }

        public double MaxTemperature
        {
            get { return maxTemperature; }
            set { maxTemperature = value; }
        }

        public double MinTemperature
        {
            get { return minTemperature; }
            set { minTemperature = value; }
        }
    }
}
