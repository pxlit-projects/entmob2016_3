using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;

namespace VegiSens.Services
{
    public interface IGrowableItemData
    {
        GrowableItem GetGrowableItemById(int growableItemID);
        ObservableCollection<GrowableItem> GetAllGrowableItems();
        void AddVegetableITem(GrowableItem growableItemToAdd);
    }
}
