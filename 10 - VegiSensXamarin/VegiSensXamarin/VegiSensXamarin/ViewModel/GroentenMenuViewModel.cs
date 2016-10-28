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
        private IFrameNavigation navigationService;
        public ICommand ViewMenuCommand { get; set; }
        public ICommand ViewDetailCommand { get; set; }
        public GroentenMenuViewModel(IFrameNavigation navigationService)
        {
           
            this.navigationService = navigationService;

            InitializeCommands();
            //InitializeMessagingCenter();
        }
        private void InitializeCommands()
        {
            ViewMenuCommand = new Command( () =>
            {
                navigationService.NavigateTo("Detail");
            });

            ViewDetailCommand = new Command(() =>
            {
                navigationService.NavigateTo("Detail");
            });


        }
    }
    }
