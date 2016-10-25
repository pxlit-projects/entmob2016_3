using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;
using VegiSens.Services;

namespace VegiSens.Test.Mocks
{
    public class MockGrowableItemDataService : IGrowableItemData
    {
        //Properties
        IVegetableRepository repository = new MockVegetableRepository();

        //Constructor
        public MockGrowableItemDataService()
        {

        }

        //Methods
        public GrowableItem GetGrowableItemById(int growableItemID)
        {
            return repository.GetGrowableItemById(growableItemID);
        }

        public ObservableCollection<GrowableItem> GetAllGrowableItems()
        {
            return repository.GetAllGrowableItems();
        }

        public void UpdateCurrentGrowableItem(GrowableItem growableItem)
        {
            throw new NotImplementedException();
        }

        public void AddVegetableItem(GrowableItem growableItemToAdd)
        {
            throw new NotImplementedException();
        }

        public void UpdateVegetableItem(GrowableItem growableItemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
