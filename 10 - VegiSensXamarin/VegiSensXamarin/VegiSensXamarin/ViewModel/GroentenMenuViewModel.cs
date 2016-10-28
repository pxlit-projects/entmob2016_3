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
    public class GroentenMenuViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public ICommand ViewMenuCommand { get; set; }
        public ICommand ViewDetailCommand { get; set; }

        public GroentenMenuViewModel(INavigationService navigationService)
        {          
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ViewDetailCommand = new Command(() =>
            {
                navigationService.NavigateTo("Detail");
            });
        }
    }
 }
