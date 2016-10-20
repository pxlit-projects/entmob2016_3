using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;

namespace VegiSens.Test.Mocks
{
    public class MockVegetableRepository : IVegetableRepository
    {
        //Properties
        private static ObservableCollection<GrowableItem> growableItems;

        //Constructor
        public MockVegetableRepository()
        {
            growableItems = this.GetAllGrowableItems();
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
                    Image = "ms-appx:///Images/Vegetables/Tomato.png",
                    Light = new Light() {MinLight = 60, MaxLight = 80},
                    Humidity = new Humidity() { Min_Ideal_Humidity= 30.5, Max_Ideal_Humidity = 35.5 },
                    Temperature = new Temperature { Min_Ideal_Temperature = 15.7, Max_Ideal_Temperature = 31.2}

                },
                new GrowableItem ()
                {
                    GrowableItemID = 2,
                    Name = "Cabbage",
                    Description = "Cabbage is very healthy and tasteful.",
                    Image = "ms-appx:///Images/Vegetables/Cabbage.png",
                    Light = new Light() {MinLight = 40, MaxLight = 50},
                    Humidity = new Humidity() { Min_Ideal_Humidity= 63, Max_Ideal_Humidity = 72.5 },
                    Temperature = new Temperature { Min_Ideal_Temperature = 23.5, Max_Ideal_Temperature = 35}

                }
            };
        }
    }
}

