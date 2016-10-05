using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.Utility;
using Windows.UI.Xaml;

namespace VegiSens.ViewModel
{
    public class LoginViewModel : SuperViewModel
    {
        //Properties
        private ICommand quitCommand { get; set; }

        //Contructor
        public LoginViewModel(IFrameNavigation frameNavagationService)
        {
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            mainPageCommand = new CustomCommand(NavigateToMainPage, CanNavigate);
            quitCommand = new CustomCommand(quitApplication, CanNavigate);
        }

        //Quit application
        private void quitApplication()
        {
            Application.Current.Exit();
        }    
    }
}
