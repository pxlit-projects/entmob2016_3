using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSensDomain;
using VegiSensXamarin.Services;

namespace VegiSensXamarin.ViewModel
{
    public abstract class SuperViewModel
    {
        //Properties
        protected IFrameNavigation frameNavagationService;
        protected IGrowableItemData growableItemService;

        protected GrowableItem currentGrowableItem;

        public ICommand GroentenMenuCommand { get; set; }
        public ICommand GroentenDetailCommand { get; set; }

        //Methods
        protected bool CanNavigate(object obj)
        {
            //Always return true
            return true;
        }

        //Navigate to MainPage
        protected void NavigateToGroentenMenu()
        {
            frameNavagationService.NavigateToFrame(typeof(GroentenMenu));
        }

        //Navigate to spectatorScreen
        protected void NavigateToGroentenDetail()
        {
            frameNavagationService.NavigateToFrame(typeof(GroentenDetail));
        }
    }
}
