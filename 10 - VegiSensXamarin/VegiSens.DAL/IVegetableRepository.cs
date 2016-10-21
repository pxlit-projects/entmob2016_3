using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensDomain;

namespace VegiSens.DAL
{
    public interface IVegetableRepository
    {
        GrowableItem GetGrowableItemById(int growableItemID);
        ObservableCollection<GrowableItem> GetAllGrowableItems();
    }
}
