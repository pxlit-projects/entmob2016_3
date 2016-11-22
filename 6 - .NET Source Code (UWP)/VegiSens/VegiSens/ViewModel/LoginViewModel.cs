using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.domain;
using VegiSens.Services;
using VegiSens.Utility;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace VegiSens.ViewModel
{
    public class LoginViewModel : SuperViewModel
    {
        //De login is geintegreerd in de applicatie maar niet goed geïmplementeert.
        //Deze is enkel aanwezig ter uitbreiding

        //Properties
        public ICommand QuitCommand { get; set; }
        private IUsernameDataService usernameDataService;

        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //Contructor
        public LoginViewModel(IFrameNavigation frameNavagationService, IUsernameDataService usernameDataService)
        {
            this.usernameDataService = usernameDataService;
            this.frameNavagationService = frameNavagationService;

            LoadCommands();
        }


        //Navigate to MainPage
        protected void NavigateToMainPageIfUserIsCorrect()
        {
            User opgehaaldeUser = usernameDataService.GetUserByName(Username);

            if (opgehaaldeUser != null)
            {
                if (opgehaaldeUser.Password == Password)
                {
                    frameNavagationService.NavigateToFrame(typeof(MainPage));
                }
                else
                {
                    ShowAuthenticationError();
                }
            }
            else
            {
                ShowAuthenticationError();
            }
        }

        private async void ShowAuthenticationError()
        {
            //Messgae confirmation
            MessageDialog dialog = new MessageDialog("Username or password is not correct!");
            dialog.Title = "Authentication error.";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            await dialog.ShowAsync();
        }

        //Load all commands
        private void LoadCommands()
        {
            MainPageCommand = new CustomCommand(NavigateToMainPageIfUserIsCorrect, CanNavigate);
            QuitCommand = new CustomCommand(QuitApplication, CanNavigate);
        }

        //Quit application
        private void QuitApplication()
        {
            Application.Current.Exit();
        }    
    }
}
