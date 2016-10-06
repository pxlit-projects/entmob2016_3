namespace VegiSens.domain
{
    public class Humidity
    {
        private int humidityID;

        private double maxHumidity;
        private double minHumidity;

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