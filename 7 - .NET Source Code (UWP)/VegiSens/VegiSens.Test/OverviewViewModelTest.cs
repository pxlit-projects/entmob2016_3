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
    public class OverviewViewModelTest
    {
        private IFrameNavigation frameNavigationService;
        private ISensorTypeData sensorTypeDataService;

        private OverviewViewModel GetViewModel()
        {
            return new OverviewViewModel(this.frameNavigationService, this.sensorTypeDataService);
        }

        [TestInitialize]
        public void Init()
        {
            frameNavigationService = new MockFrameNavigationService();
            sensorTypeDataService = new MockSensorTypeDataService();
        }

        [TestMethod]
        public void OverviewViewModel_LoadAllSensorTypes()
        {
            //Arrange
            ObservableCollection<SuperSensor> sensorTypes = null;
            ObservableCollection<SuperSensor> expectedSensorTypes = sensorTypeDataService.GetAllSensorTypes();

            //act
            OverviewViewModel viewModel = GetViewModel();
            sensorTypes = viewModel.SensorTypeList;

            //assert
            CollectionAssert.AreEqual(expectedSensorTypes, sensorTypes);
        }
    }
}
