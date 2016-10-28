using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSensXamarin.Constants;
using VegiSensXamarin.Services;
using Xamarin.Forms;

namespace VegiSensXamarin.ViewModel
{
    public class GroentenDetailViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public ICommand ViewMenuCommand { get; set; }
        public ICommand ViewDetailCommand { get; set; }

        public GroentenDetailViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ViewMenuCommand = new Command(() =>
           {
               navigationService.NavigateTo("Menu");
           });
        }
    }
}
