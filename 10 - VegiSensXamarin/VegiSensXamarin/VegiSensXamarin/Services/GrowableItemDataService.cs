using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSensDomain;

namespace VegiSensXamarin.Services
{
    public class GrowableItemDataService : IGrowableItemDataService
    {
        //Properties
        IVegetableRepository repository;

        //Constructor
        public GrowableItemDataService(IVegetableRepository repository)
        {
            this.repository = repository;
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
