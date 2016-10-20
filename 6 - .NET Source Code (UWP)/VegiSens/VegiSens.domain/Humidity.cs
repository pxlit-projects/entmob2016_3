using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegiSens.domain
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