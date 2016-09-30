namespace VegiSens.domain
{
    public class Temperature
    {
        private int temperatureID;

        private double maxTemperature;
        private double minTemperature;

        public double MaxTemperature
        {
            get { return maxTemperature; }
            set { maxTemperature = value; }
        }

        public double MinTemperature
        {
            get { return minTemperature; }
            set { minTemperature = value; }
        }
    }
}