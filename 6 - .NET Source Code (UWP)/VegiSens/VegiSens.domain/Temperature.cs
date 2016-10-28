using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegiSens.domain
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