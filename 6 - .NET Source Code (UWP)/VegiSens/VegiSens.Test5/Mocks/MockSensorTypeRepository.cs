using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;

namespace VegiSens.Test.Mocks
{
    public class MockSensorTypeRepository : ISensorTypeRepository
    {
        //Properties
        private static ObservableCollection<SuperSensor> sensorTypes;

        //Constructor
        public MockSensorTypeRepository()
        {
            sensorTypes = this.GetAllSensorTypes();
        }

        public ObservableCollection<SuperSensor> GetAllSensorTypes()
        {
            if (sensorTypes == null)
            {
                loadSensorTypeItems();
            }

            return sensorTypes;
        }


        //Load all data
        private void loadSensorTypeItems()
        {
            sensorTypes = new ObservableCollection<SuperSensor>()
            {
                new HumiditySensorType()
                {
                    SensorName = "Humidity sensor",
                    RegisteredHumidityValues = new ObservableCollection<double>()
                    {
                        31.5,
                        33.8,
                        45.6,
                        78.4,
                        23.6,
                        55.0,
                        24.8
                    },
                    SensorUnit = "(%)"

                },
                new TemperatureSensorType()
                {
                    SensorName = "Temperature sensor",
                    RegisteredTemperatureValues = new ObservableCollection<double>()
                    {
                        23.5,
                        24.8,
                        23.6,
                        25.4,
                        30.6,
                        19.0,
                        22.8
                    },
                    SensorUnit = "(°C)"
                },
                new LightSensorType()
                {
                    SensorName = "Light sensor",
                    RegisteredLightValues = new ObservableCollection<double>()
                    {
                        80.5,
                        110.8,
                        68.6,
                        120.4,
                        140.6,
                        145.0,
                        60.8
                    },
                    SensorUnit = "(lx)"
                }
            };
        }
    }
}
