using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.domain;
using VegiSens.Services;
using VegiSens.Utility;
using VegiSens.ViewModel;

namespace VegiSens.ViewModel
{
    public class SpectatorScreenViewModel : SuperViewModel
    {
        //Contructor
        public SpectatorScreenViewModel(IFrameNavigation frameNavagationService, IGrowableItemData growableItemService)
        {
            this.growableItemService = growableItemService;
            this.frameNavagationService = frameNavagationService;

            LoadData();

            LoadCommands();
        }


        //Load all commands
        private void LoadCommands()
        {
            MainPageCommand = new CustomCommand(NavigateToMainPage, CanNavigate);
            OverviewCommand = new CustomCommand(NavigateToOverview, CanNavigate);
            SelectVegetableCommand = new CustomCommand(NavigateToSelectVegetable, CanNavigate);
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
