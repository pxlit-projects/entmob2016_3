using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSensXamarin.Services;
using VegiSensXamarin.ViewModel;

namespace VegiSensXamarin.Locator
{
     public class ViewModelLocator
    {
        //Services
       
        private static IFrameNavigation navService = new FrameNavigationService();

        //ViewModels
        
        private static GroentenMenuViewModel groentenMenuViewModel = new GroentenMenuViewModel(navService);

        //Properties
        

        public static GroentenMenuViewModel GroentenMenuViewModel
        {
            get
            {
                return groentenMenuViewModel;
            }
        }
    }
}
