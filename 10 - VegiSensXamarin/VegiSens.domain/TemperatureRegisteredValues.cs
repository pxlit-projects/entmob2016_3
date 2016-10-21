using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSens.domain
{
    public class TemperatureRegisteredValues
    {
        private int temperatureRegisteredId;

        private Object date;
        private double tempValue;

        public int TemperatureRegisteredId
        {
            get { return temperatureRegisteredId; }
            set { temperatureRegisteredId = value; }
        }

        public Object Date
        {
            get { return date; }
            set { date = value.ToString(); }
        }

        public double Value
        {
            get { return tempValue; }
            set { tempValue = value; }
        }

    }
}
