using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Services;
using VegiSensXamarin.ViewModel;
using VegiSens.Test.Mocks;
using System.Collections.ObjectModel;
using VegiSensDomain;
using VegiSensXamarin.Utility;

namespace VegiSens.Test
{
    [TestClass]
    public class GroentenDetailViewModelTest
    {
        private INavigationService navigationService;
        private IGrowableItemDataService growableItemDataSerivce;

        private GroentenDetailViewModel GetViewModel()
        {
            return new GroentenDetailViewModel(this.navigationService);
        }

        [TestInitialize]
        public void Init()
        {
            navigationService = new MockNavigationService();
            growableItemDataSerivce = new MockGrowableItemDataService();
        }

        [TestMethod]
        public void GroentenDetailViewModel_GetGrowableItemById()
        {
            //Arrange
            GrowableItem growableItem = null;
            GrowableItem expectedGrowableItem = growableItemDataSerivce.GetGrowableItemById(1);

            //act
            GroentenDetailViewModel viewModel = GetViewModel();

            //Send message with vegetable so the viewmodel receives it
            Messenger.Default.Send<GrowableItem>(expectedGrowableItem);

            growableItem = viewModel.CurrentGrowableItem;

            //assert
            Assert.AreEqual(expectedGrowableItem, growableItem);
        }
    }
}
