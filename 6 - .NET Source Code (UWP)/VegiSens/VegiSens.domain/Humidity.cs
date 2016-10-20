using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegiSens.domain
{
    public class Humidity
    {
        public Humidity()
        {
            GrowableItems = new List<GrowableItem>();

        }

        [Key]
        private int humidityID;

        private double maxHumidity;
        private double minHumidity;

        public virtual ICollection<GrowableItem> GrowableItems { get; set; }

        public int Id
        {
            get { return humidityID; }
            set { humidityID = value; }

        }

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