using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSens.domain
{
    public class GrowableItem
    {
        private int growableItemID;

        private string name;
        private string description;
        private string imagePath;

        private Temperature temperature;
        private Moisture moisture;
        private Light light;


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

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public Temperature Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public Moisture Moisture
        {
            get { return moisture; }
            set { moisture = value; }
        }

        public Light Light
        {
            get { return light; }
            set { light = value; }
        }
    }
}
