using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;
using VegiSens.DAL;
using System.Collections.ObjectModel;
using VegiSens.Services;
using VegiSens.ViewModel;
using VegiSens.Utility;
using VegiSens.Test.Mocks;

namespace VegiSens.Test
{
    [TestClass]
    public class SpectatorScreenViewModelTest
    {
        private IGrowableItemData growableItemDataSerivce;
        private IFrameNavigation frameNavigationService;
        private ISensorTypeData sensorTypeDataService;

        private SpectatorScreenViewModel GetViewModel()
        {
            return new SpectatorScreenViewModel(this.frameNavigationService, this.growableItemDataSerivce, this.sensorTypeDataService);
        }

        [TestInitialize]
        public void Init()
        {
            growableItemDataSerivce = new MockGrowableItemDataService();
            frameNavigationService = new MockFrameNavigationService();
            sensorTypeDataService = new MockSensorTypeDataService();
        }

        [TestMethod]
        public void SpectatorScreen_LoadAllSensorTypes()
        {
            //Arrange
            ObservableCollection<SensorType> sensorTypes = null;
            ObservableCollection<SensorType> expectedSensorTypes = sensorTypeDataService.GetAllSensorTypes();

            //act
            SpectatorScreenViewModel viewModel = GetViewModel();
            sensorTypes = viewModel.sensorTypeList;

            //assert
            CollectionAssert.AreEqual(expectedSensorTypes, sensorTypes);
        }

        [TestMethod]
        public void SpectatorScreen_GetGrowableItemById()
        {
            //Arrange
            GrowableItem growableItem = null;
            GrowableItem expectedGrowableItem = growableItemDataSerivce.GetGrowableItemById(1);

            //act
            SpectatorScreenViewModel viewModel = GetViewModel();
            growableItem = viewModel.CurrentGrowableItem;

            //assert
            Assert.AreEqual(expectedGrowableItem, growableItem);
        }
    }
}
