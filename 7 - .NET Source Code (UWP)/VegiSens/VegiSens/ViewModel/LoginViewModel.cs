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
        private ICommand QuitCommand { get; set; }

        //Contructor
        public LoginViewModel(IFrameNavigation frameNavagationService)
        {
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            MainPageCommand = new CustomCommand(NavigateToMainPage, CanNavigate);
            QuitCommand = new CustomCommand(QuitApplication, CanNavigate);
        }

        //Quit application
        private void QuitApplication()
        {
            Application.Current.Exit();
        }    
    }
}
