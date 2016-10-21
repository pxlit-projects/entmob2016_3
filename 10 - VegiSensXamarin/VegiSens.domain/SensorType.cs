using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSens.domain
{
    public class SensorType
    {
        private int sensortypeId;

        private string sensorName;
        private string sensorUnit;

        private List<HumidityRegisteredValues> humidityValues;
        private List<TemperatureRegisteredValues> temperatureValues;

        private ObservableCollection<double> values = new ObservableCollection<double>();
        private ObservableCollection<string> dates = new ObservableCollection<string>();

        public int SensortypeId
        {
            get { return sensortypeId; }
            set { sensortypeId = value; }
        }

        public string SensorName
        {
            get { return sensorName; }
            set { sensorName = value; }
        }

        public string SensorUnit
        {
            get { return sensorUnit; }
            set { sensorUnit = value; }
        }

        public List<TemperatureRegisteredValues> TemperatureValues
        {
            get { return temperatureValues; }
            set { temperatureValues = value; }
        }

        public List<HumidityRegisteredValues> HumidityValues
        {
            get { return humidityValues; }
            set { humidityValues = value; }
        }

        public ObservableCollection<double> Values
        {
            get { return values; }
            set { values = value; }
        }

        public ObservableCollection<string> Dates
        {
            get { return dates; }
            set { dates = value; }
        }

        //Set the data for the specified sensor
        public void SetValues(SensorType currentSensor)
        {
            this.Values.Clear();

            if (currentSensor.sensorName == "Temperature Sensor")
            {
                foreach (var temperature in currentSensor.temperatureValues)
                {
                    this.Values.Add(temperature.Value);
                }
            }
            else if (currentSensor.sensorName == "Humidity Sensor")
            {
                foreach (var humidity in currentSensor.humidityValues)
                {
                    this.Values.Add(humidity.Value);
                }
            }
        }

        //Set the date for the specified sensor
        public void SetDates(SensorType currentSensor)
        {
            this.Dates.Clear();

            if (currentSensor.sensorName == "Temperature Sensor")
            {
                foreach (var temperature in currentSensor.temperatureValues)
                {
                    this.Dates.Add(MakeDateOfOutString(temperature, true));
                }
            }
            else if (currentSensor.sensorName == "Humidity Sensor")
            {
                foreach (var humidity in currentSensor.humidityValues)
                {
                    this.Dates.Add(MakeDateOfOutString(humidity, false));
                }
            }
        }

        private string MakeDateOfOutString(Object item, bool checkType)
        {
            string date;

            if (checkType)
            {
                date = ((TemperatureRegisteredValues)item).Date.ToString();
            }
            else
            {
                date = ((HumidityRegisteredValues)item).Date.ToString();
            }

            string dateFormatter;

            //Day
            int beginIndex = date.IndexOf(':');
            int endIndex = date.IndexOf(',');

            dateFormatter = date.Remove(endIndex);

            string day = dateFormatter.Substring(beginIndex + 2);

            //Month
            beginIndex = date.IndexOf("monthValue");

            dateFormatter = date.Substring(beginIndex);


            endIndex = dateFormatter.IndexOf(',');

            dateFormatter = dateFormatter.Remove(endIndex);

            beginIndex = dateFormatter.IndexOf(':');

            string month = dateFormatter.Substring(beginIndex + 2);

            //Year
            beginIndex = date.IndexOf("year");

            dateFormatter = date.Substring(beginIndex);

            endIndex = dateFormatter.IndexOf(',');

            dateFormatter = dateFormatter.Remove(endIndex);

            beginIndex = dateFormatter.IndexOf(':');

            string year = dateFormatter.Substring(beginIndex + 2);

            return String.Format("{0}/{1}/{2}", day, month, year);
        }
    }
}
