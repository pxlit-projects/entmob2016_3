using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.Utility;

namespace VegiSens.ViewModel
{
    public class MainPageViewModel : SuperViewModel
    {
        //Contructor
        public MainPageViewModel(IFrameNavigation frameNavagationService)
        {
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            spectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
            loginCommand = new CustomCommand(NavigateToLogin, CanNavigate);
        }
    }
}
