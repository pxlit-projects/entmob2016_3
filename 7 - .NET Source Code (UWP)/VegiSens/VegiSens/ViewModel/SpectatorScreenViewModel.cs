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
    public class SpectatorScreenViewModel : SuperViewModel
    {
        //Contructor
        public SpectatorScreenViewModel(IFrameNavigation frameNavagationService)
        {
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            mainPageCommand = new CustomCommand(NavigateToMainPage, CanNavigate);
            overviewCommand = new CustomCommand(NavigateToOverview, CanNavigate);
            selectVegetableCommand = new CustomCommand(NavigateToSelectVegetable, CanNavigate);
        }
    }
}
