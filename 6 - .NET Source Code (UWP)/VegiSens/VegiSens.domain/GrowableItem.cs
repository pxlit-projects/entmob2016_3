using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VegiSens.domain
{
    public class GrowableItem
    {
        [Key]
        private int growableItemID;

        private string name;
        private string description;
        private string imagePath;
    
        private int Temperature_FK { get; set; }
        [ForeignKey("Temperature_FK")]
        private Temperature temperature;

        private int Humidity_FK { get; set; }
        [ForeignKey("Humidity_FK")]
        private Humidity humidity;

        private int LightID { get; set; }
        [ForeignKey("LightID")]
        private Light light;

        public int GrowableItemID
        {
            get { return growableItemID; }
            set { growableItemID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Image
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public Temperature Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public Humidity Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        public Light Light
        {
            get { return light; }
            set { light = value; }
        }
    }
}
