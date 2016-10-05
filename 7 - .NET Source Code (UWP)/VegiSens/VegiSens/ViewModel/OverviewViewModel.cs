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
    public class OverviewViewModel : SuperViewModel
    {
        //Contructor
        public OverviewViewModel(IFrameNavigation frameNavagationService)
        {
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            spectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
        }
    }
}
