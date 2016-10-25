using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.Utility;
using VegiSens.ViewModel;
using VegiSens.Services;
using VegiSens.DAL;

namespace VegiSens.Locator
{
    public class ViewModelLocator
    {
        //Services
        private static ISensorTypeData sensorTypeDataService = new SensorTypeDataService(new SensorTypeRepository());
        private static IFrameNavigation frameNavigationService = new FrameNavigationService();
        private static IGrowableItemData growableItemService = new GrowableItemDataService(new VegetableRepository());
        private static IUsernameDataService userService = new UsernameDataService(new UserRepository());

        //ViewModels
        private static MainPageViewModel mainPageViewModel = new MainPageViewModel(frameNavigationService, growableItemService);
        private static LoginViewModel loginViewModel = new LoginViewModel(frameNavigationService, userService);
        private static SelectVegetableViewModel selectVegetableViewModel = new SelectVegetableViewModel(frameNavigationService, growableItemService);
        private static SpectatorScreenViewModel spectatorScreenModel = new SpectatorScreenViewModel(frameNavigationService, growableItemService, sensorTypeDataService);
        private static OverviewViewModel overviewViewModel = new OverviewViewModel(frameNavigationService, sensorTypeDataService);
        private static AddVegetableViewModel addVegetableViewModel = new AddVegetableViewModel(frameNavigationService, growableItemService);
        private static UpdateVegetableViewModel updateVegetableViewModel = new UpdateVegetableViewModel(frameNavigationService, growableItemService);

        //Properties
        public static MainPageViewModel MainPageViewModel
        {
            get
            {
                return mainPageViewModel;
            }
        }

        public static LoginViewModel LoginViewModel
        {
            get
            {
                return loginViewModel;
            }
        }

        public static UpdateVegetableViewModel UpdateVegetableViewModel
        {
            get
            {
                return updateVegetableViewModel;
            }
        }

        public static SelectVegetableViewModel SelectVegetableViewModel
        {
            get
            {
                return selectVegetableViewModel;
            }
        }

        public static SpectatorScreenViewModel SpectatorScreenModel
        {
            get
            {
                return spectatorScreenModel;
            }
        }

        public static OverviewViewModel OverviewViewModel
        {
            get
            {
                return overviewViewModel;
            }
        }

        public static AddVegetableViewModel AddVegetableViewModel
        {
            get
            {
                return addVegetableViewModel;
            }
        }
    }
}
