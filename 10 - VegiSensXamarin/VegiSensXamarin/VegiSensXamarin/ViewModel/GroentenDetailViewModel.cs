using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSensXamarin.Services;
using Xamarin.Forms;
using VegiSensDomain;
using VegiSensXamarin.Utility;

namespace VegiSensXamarin.ViewModel
{
    public class GroentenDetailViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public ICommand ViewMenuCommand { get; set; }


        public GrowableItem CurrentGrowableItem { get; set; }

        public GroentenDetailViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            Messenger.Default.Register<GrowableItem>(this, OnReceiveGrowableItem);

            InitializeCommands();
        }

        private void OnReceiveGrowableItem(GrowableItem receivedGrowableItem)
        {
            this.CurrentGrowableItem = receivedGrowableItem;
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
