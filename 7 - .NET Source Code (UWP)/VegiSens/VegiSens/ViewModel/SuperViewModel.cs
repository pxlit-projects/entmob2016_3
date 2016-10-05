using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.Utility;
using VegiSens.ViewModel;

namespace VegiSens.ViewModel
{
    public abstract class SuperViewModel
    {
        //Properties
        protected IFrameNavigation frameNavagationService;

        
        public ICommand mainPageCommand { get; set; }
        public ICommand spectatorCommand { get; set; }
        public ICommand loginCommand { get; set; }
        public ICommand selectVegetableCommand { get; set; }
        public ICommand overviewCommand { get; set; }

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

        //Navigate to overview
        protected void NavigateToOverview()
        {
            frameNavagationService.NavigateToFrame(typeof(Overview));
        }

        //Navigate to selectVegetable
        protected void NavigateToSelectVegetable()
        {
            frameNavagationService.NavigateToFrame(typeof(SelectVegetable));
        }
    }
}
