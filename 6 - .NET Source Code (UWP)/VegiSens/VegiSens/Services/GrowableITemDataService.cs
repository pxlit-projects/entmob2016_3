using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;

namespace VegiSens.Services
{
    public class GrowableItemDataService : IGrowableItemData
    {
        //Properties
        IVegetableRepository repository;

        //Constructor
        public GrowableItemDataService(IVegetableRepository repository)
        {
            this.repository = repository;
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

        public void AddVegetableItem(GrowableItem growableItemToAdd)
        {
            repository.AddVegetableItem(growableItemToAdd);
        }

        public void UpdateVegetableItem(GrowableItem growableItemToUpdate)
        {
            repository.UpdateVegetableItem(growableItemToUpdate);
        }
    }
}
