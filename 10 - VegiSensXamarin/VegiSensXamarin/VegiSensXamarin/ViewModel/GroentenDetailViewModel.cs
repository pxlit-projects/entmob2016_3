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
    class GroentenDetailViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public ICommand ViewMenuCommand { get; set; }
        public ICommand ViewDetailCommand { get; set; }

        private void InitializeCommands()
        {
            ViewMenuCommand = new Command(async () =>
            {
                await navigationService.PushModalAsync(PageUrls.VegetableMenuView);
            });

            ViewDetailCommand = new Command(async () =>
            {
                await navigationService.PushAsync(PageUrls.VegetableDetailView);
            });


        }
    }
}
