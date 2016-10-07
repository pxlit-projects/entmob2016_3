using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace VegiSens.domain
{
    public class HumiditySensorType : SuperSensor
    {
        private ObservableCollection<double> registeredHumidityValues;

        public ObservableCollection<double> RegisteredHumidityValues
        {
            get { return registeredHumidityValues; }
            set { registeredHumidityValues = value; }
        }

        public double GetFirstRegisteredItem
        {
            get { return registeredHumidityValues[0]; }
        }

        public double GetSecondRegisteredItem
        {
            get { return registeredHumidityValues[1]; }
        }

        public double GetThirdRegisteredItem
        {
            get { return registeredHumidityValues[2]; }
        }

        public double GetForthRegisteredItem
        {
            get { return registeredHumidityValues[3]; }
        }

        public double GetFifthRegisteredItem
        {
            get { return registeredHumidityValues[4]; }
        }

        public double GetSixtRegisteredItem
        {
            get { return registeredHumidityValues[5]; }
        }

        public double GetSeventhRegisteredItem
        {
            get { return registeredHumidityValues[6]; }
        }
    }
}
