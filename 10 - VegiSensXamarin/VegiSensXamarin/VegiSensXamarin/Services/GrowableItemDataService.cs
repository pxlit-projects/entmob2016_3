using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensDomain;
using VegiSens.DAL;

namespace VegiSensXamarin.Services
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

        GrowableItem IGrowableItemData.GetGrowableItemById(int growableItemID)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<GrowableItem> IGrowableItemData.GetAllGrowableItems()
        {
            throw new NotImplementedException();
        }
    }
}
