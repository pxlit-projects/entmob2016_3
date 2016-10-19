using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegiSens.domain
{
    public class Light
    {
        public Light()
        {
            GrowableItems = new List<GrowableItem>();
        }

        [Key]
        private int lightID;

        private double maxLight;
        private double minLight;

        public virtual ICollection<GrowableItem> GrowableItems { get; set; }

        public int LightID
        {
            get { return lightID; }
            set { lightID = value; }
        }

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