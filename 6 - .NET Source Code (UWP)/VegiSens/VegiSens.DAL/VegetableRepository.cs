using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;

namespace VegiSens.DAL
{
    public class VegetableRepository : IVegetableRepository
    {
        //Properties
        private static ObservableCollection<GrowableItem> growableItems;

        //Constructor
        public VegetableRepository()
        {
        }

        public ObservableCollection<GrowableItem> GetAllGrowableItems()
        {
            if (growableItems == null)
            {
                loadGrowableItems();
            }

            return growableItems;
        }

        //Methods
        public GrowableItem GetGrowableItemById(int growableItemID)
        {
            if (growableItems == null)
            {
                loadGrowableItems();
            }

            return growableItems.Where(g => g.GrowableItemID == growableItemID).FirstOrDefault();
        }

        //Load all data
        private void loadGrowableItems()
        {
            growableItems = new ObservableCollection<GrowableItem>()
            {
                new GrowableItem ()
                {
                    GrowableItemID = 1,
                    Name = "Red tomato",
                    Description = "Red tomatos are very tasteful and delicious!",
                    ImagePath = "ms-appx:///Images/Vegetables/Tomato.png",
                    Light = new Light() {MinLight = 60, MaxLight = 80},
                    Humidity = new Humidity() { MinHumidity= 30.5, MaxHumidity = 35.5 },
                    Temperature = new Temperature { MinTemperature = 15.7, MaxTemperature = 31.2}

                },
                new GrowableItem ()
                {
                    GrowableItemID = 2,
                    Name = "Cabbage",
                    Description = "Cabbage is very healthy and tasteful.",
                    ImagePath = "ms-appx:///Images/Vegetables/Cabbage.png",
                    Light = new Light() {MinLight = 40, MaxLight = 50},
                    Humidity = new Humidity() { MinHumidity= 63, MaxHumidity = 72.5 },
                    Temperature = new Temperature { MinTemperature = 23.5, MaxTemperature = 35}

                }
            };
        }
    }
}
