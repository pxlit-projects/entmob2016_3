using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSensDomain
{
    public class GrowableItem
    {
        private int growableItemId;

        private string name;
        private string description;
        private string image;

        private Temperature temperature;
        private Humidity humidity;

        public int GrowableItemID
        {
            get { return growableItemId; }
            set { growableItemId = value; }
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
            get { return image; }
            set { image = value; }
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
    }
}
