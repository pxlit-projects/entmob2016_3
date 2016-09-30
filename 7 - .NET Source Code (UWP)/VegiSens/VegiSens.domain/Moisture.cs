namespace VegiSens.domain
{
    public class Moisture
    {
        private int moistureID;

        private double maxMoisture;
        private double minMoisture;

        public double MaxMoisture
        {
            get { return maxMoisture; }
            set { maxMoisture = value; }
        }

        public double MinMoisture
        {
            get { return minMoisture; }
            set { minMoisture = value; }
        }
    }
}