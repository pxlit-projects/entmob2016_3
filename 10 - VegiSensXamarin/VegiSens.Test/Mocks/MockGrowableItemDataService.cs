using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSensDomain;
using VegiSensXamarin.Services;

namespace VegiSens.Test.Mocks
{
    public class MockGrowableItemDataService : IGrowableItemDataService
    {
        //Properties
        IVegetableRepository repository = new MockVegetableRepository();

        //Constructor
        public MockGrowableItemDataService()
        {

        }

        //Methods
        public ObservableCollection<GrowableItem> GetAllGrowableItems()
        {
            return repository.GetAllGrowableItems();
        }

        public GrowableItem GetGrowableItemById(int growableItemID)
        {
            return repository.GetGrowableItemById(growableItemID);
        }
    }
}
