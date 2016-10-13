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
    public class MainPageViewModelTest
    {
        private IGrowableItemData growableItemDataSerivce;
        private IFrameNavigation frameNavigationService;

        private MainPageViewModel GetViewModel()
        {
            return new MainPageViewModel(this.frameNavigationService, this.growableItemDataSerivce);
        }

        [TestInitialize]
        public void Init()
        {
            growableItemDataSerivce = new MockGrowableItemDataService();
            frameNavigationService = new MockFrameNavigationService();
        }

        [TestMethod]
        public void MainPage_GetGrowableItemById()
        {
            //Arrange
            GrowableItem growableItem = null;
            GrowableItem expectedGrowableItem = growableItemDataSerivce.GetGrowableItemById(1);

            //act
            MainPageViewModel viewModel = GetViewModel();
            growableItem = viewModel.CurrentGrowableItem;

            //assert
            Assert.AreEqual(expectedGrowableItem, growableItem);
        }
    }
}
