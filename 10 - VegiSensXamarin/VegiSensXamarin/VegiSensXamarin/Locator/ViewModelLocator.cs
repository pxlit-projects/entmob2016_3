using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Services;
using VegiSensXamarin.ViewModel;
using VegiSens.DAL;

namespace VegiSensXamarin.Locator
{
     public class ViewModelLocator
    {
        //Services      
        private static INavigationService navigationService = new NavigationService();
        private static IGrowableItemDataService growableDataService = new GrowableItemDataService(new VegetableRepository());

        //ViewModels
        private static GroentenMenuViewModel groentenMenuViewModel = new GroentenMenuViewModel(navigationService, growableDataService);
        private static GroentenDetailViewModel groentenDetailViewModel = new GroentenDetailViewModel(navigationService);

        //Properties
        public static GroentenMenuViewModel GroentenMenuViewModel
        {
            get
            {
                return groentenMenuViewModel;
            }
        }

        public static GroentenDetailViewModel GroentenDetailViewModel
        {
            get
            {
                return groentenDetailViewModel;
            }
        }
    }
}
