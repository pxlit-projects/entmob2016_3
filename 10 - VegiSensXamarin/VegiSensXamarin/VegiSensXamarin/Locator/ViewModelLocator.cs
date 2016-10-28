using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Services;
using VegiSensXamarin.ViewModel;

namespace VegiSensXamarin.Locator
{
     public class ViewModelLocator
    {
        //Services      
        private static INavigationService navigationService = new NavigationService();

        //ViewModels
        private static GroentenMenuViewModel groentenMenuViewModel = new GroentenMenuViewModel(navigationService);
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
