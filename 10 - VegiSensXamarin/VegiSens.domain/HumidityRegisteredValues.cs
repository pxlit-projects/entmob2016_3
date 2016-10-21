using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSens.domain
{
    public class HumidityRegisteredValues
    {
        private int humidityRegisteredId;

        private Object date;
        private double humValue;

        public int HumidityRegisteredId
        {
            get { return humidityRegisteredId; }
            set { humidityRegisteredId = value; }
        }

        public Object Date
        {
            get { return date; }
            set { date = value.ToString(); }
        }

        public double Value
        {
            get { return humValue; }
            set { humValue = value; }
        }
    }
}
