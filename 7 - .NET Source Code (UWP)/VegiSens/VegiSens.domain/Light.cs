namespace VegiSens.domain
{
    public class Light
    {
        private int lightID;

        private double maxLight;
        private double minLight;

        public double MaxLight
        {
            get { return maxLight; }
            set { maxLight = value; }
        }

        public double MinLight
        {
            get { return minLight; }
            set { minLight = value; }
        }
    }
}