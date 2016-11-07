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
    public class GroentenMenuViewModelTest
    {
        private INavigationService navigationService;
        private IGrowableItemDataService growableItemDataSerivce;

        private GroentenMenuViewModel GetViewModel()
        {
            return new GroentenMenuViewModel(this.navigationService, this.growableItemDataSerivce);
        }

        [TestInitialize]
        public void Init()
        {
            navigationService = new MockNavigationService();
            growableItemDataSerivce = new MockGrowableItemDataService();
        }

        [TestMethod]
        public void GroentenMenuViewModel_GetAllGrowableItems()
        {
            //Arrange
            ObservableCollection<GrowableItem> growableItems = null;
            ObservableCollection<GrowableItem> expectedGrowableItems = growableItemDataSerivce.GetAllGrowableItems();

            //act
            GroentenMenuViewModel viewModel = GetViewModel();

            growableItems = viewModel.GrowableItemListToSend;

            //assert
            CollectionAssert.AreEqual(expectedGrowableItems, growableItems);
        }
    }
}
