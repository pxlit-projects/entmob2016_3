using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VegiSens.domain
{
    public class LightSensorType : SuperSensor
    {
        private ObservableCollection<double> registeredLightValues;

        public ObservableCollection<double> RegisteredLightValues
        {
            get { return registeredLightValues; }
            set { registeredLightValues = value; }
        }

        public double GetFirstRegisteredItem
        {
            get { return registeredLightValues[0]; }
        }

        public double GetSecondRegisteredItem
        {
            get { return registeredLightValues[1]; }
        }

        public double GetThirdRegisteredItem
        {
            get { return registeredLightValues[2]; }
        }

        public double GetForthRegisteredItem
        {
            get { return registeredLightValues[3]; }
        }

        public double GetFifthRegisteredItem
        {
            get { return registeredLightValues[4]; }
        }

        public double GetSixtRegisteredItem
        {
            get { return registeredLightValues[5]; }
        }

        public double GetSeventhRegisteredItem
        {
            get { return registeredLightValues[6]; }
        }
    }
}
