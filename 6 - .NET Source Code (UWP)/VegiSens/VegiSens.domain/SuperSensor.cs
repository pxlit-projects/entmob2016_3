using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSens.domain
{
    public class SuperSensor
    {
        protected string sensorName;
        protected string sensorUnit;

        public string SensorUnit
        {
            get { return sensorUnit; }
            set { sensorUnit = value; }
        }

        public string SensorName
        {
            get { return sensorName; }
            set { sensorName = value; }
        }


    }
}
