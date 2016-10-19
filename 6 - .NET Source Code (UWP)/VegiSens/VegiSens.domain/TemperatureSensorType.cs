using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VegiSens.domain
{
    public class TemperatureSensorType : SuperSensor
    {
        private ObservableCollection<double> registeredTemperatureValues;

        public ObservableCollection<double> RegisteredTemperatureValues
        {
            get { return registeredTemperatureValues; }
            set { registeredTemperatureValues = value; }
        }

        public double GetFirstRegisteredItem
        {
            get { return registeredTemperatureValues[0]; }
        }

        public double GetSecondRegisteredItem
        {
            get { return registeredTemperatureValues[1]; }
        }

        public double GetThirdRegisteredItem
        {
            get { return registeredTemperatureValues[2]; }
        }

        public double GetForthRegisteredItem
        {
            get { return registeredTemperatureValues[3]; }
        }

        public double GetFifthRegisteredItem
        {
            get { return registeredTemperatureValues[4]; }
        }

        public double GetSixtRegisteredItem
        {
            get { return registeredTemperatureValues[5]; }
        }

        public double GetSeventhRegisteredItem
        {
            get { return registeredTemperatureValues[6]; }
        }
    }
}
