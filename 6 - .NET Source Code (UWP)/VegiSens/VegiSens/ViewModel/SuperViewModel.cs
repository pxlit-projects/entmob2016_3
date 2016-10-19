using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.domain;
using VegiSens.Utility;
using VegiSens.Services;
using VegiSens.ViewModel;

namespace VegiSens.ViewModel
{
    public abstract class SuperViewModel
    {
        //Properties
        protected IFrameNavigation frameNavagationService;
        protected IGrowableItemData growableItemService;

        protected GrowableItem currentGrowableItem;

        public ICommand MainPageCommand { get; set; }
        public ICommand SpectatorCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand SelectVegetableCommand { get; set; }
        public ICommand OverviewCommand { get; set; }

        //Methods
        protected bool CanNavigate(object obj)
        {
            //Always return true
            return true;
        }

        //Navigate to MainPage
        protected void NavigateToMainPage()
        {
            frameNavagationService.NavigateToFrame(typeof(MainPage));
        }

        //Navigate to spectatorScreen
        protected void NavigateToSpectate()
        {
            frameNavagationService.NavigateToFrame(typeof(SpectatorScreen));
        }

        //Navigate to login
        protected void NavigateToLogin()
        {
            frameNavagationService.NavigateToFrame(typeof(Login));
        }

        //Navigate to selectVegetable
        protected void NavigateToSelectVegetable()
        {
            frameNavagationService.NavigateToFrame(typeof(SelectVegetable));
        }
    }
}
