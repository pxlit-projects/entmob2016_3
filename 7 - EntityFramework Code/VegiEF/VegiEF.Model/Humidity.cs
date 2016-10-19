using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiEF.Model
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

        public int HumidityID { get { return humidityID; } set { humidityID = value; } }
        public double MaxHumidity { get { return maxHumidity; } set { maxHumidity = value; } }
        public double MinHumidity { get { return minHumidity; } set { minHumidity = value; } }
    }
}
