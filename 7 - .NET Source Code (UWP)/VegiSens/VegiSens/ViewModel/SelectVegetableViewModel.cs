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
    public class SelectVegetableViewModel : SuperViewModel
    {
        public ICommand saveCommand { get; set; }

        //Contructor
        public SelectVegetableViewModel(IFrameNavigation frameNavagationService)
        {
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            spectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
            saveCommand = new CustomCommand(saveVegetable, CanNavigate);
        }

        //Quit application
        private void saveVegetable()
        {

        }
    }
}
