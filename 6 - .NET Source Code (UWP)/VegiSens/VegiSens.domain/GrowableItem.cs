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
        private int growableItemId;

        private string nam;
        private string description;
        private string image;
    
        private Temperature temperature;
        private Humidity humidity;

        public int GrowableItemID
        {
            get { return growableItemId; }
            set { growableItemId = value; }
        }

        public string name
        {
            get { return nam; }
            set { nam = value; }
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
