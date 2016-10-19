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

namespace VegiSens.ViewModel
{
    public class MainPageViewModel : SuperViewModel
    {
        //Contructor
        public MainPageViewModel(IFrameNavigation frameNavagationService, IGrowableItemData growableItemService)
        {
            this.growableItemService = growableItemService;
            this.frameNavagationService = frameNavagationService;

            LoadData();

            LoadCommands();

            Messenger.Default.Register<GrowableItem>(this, OnGrowableItemReceived);
        }

        //User received
        private void OnGrowableItemReceived(GrowableItem growbaleItem)
        {
            currentGrowableItem = growbaleItem;
        }

        //Load all commands
        private void LoadCommands()
        {
            SpectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
            LoginCommand = new CustomCommand(NavigateToLogin, CanNavigate);
        }

        //Load all data
        private void LoadData()
        {
            currentGrowableItem = growableItemService.GetGrowableItemById(1);
        }

        public GrowableItem CurrentGrowableItem
        {
            get { return currentGrowableItem; }
            set { currentGrowableItem = value; }
        }
    }
}
