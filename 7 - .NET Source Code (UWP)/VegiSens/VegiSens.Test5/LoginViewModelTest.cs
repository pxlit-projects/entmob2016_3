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
    public class LoginViewModelTest
    {
        private IUsernameDataService userDataSerivce;
        private IFrameNavigation frameNavigationService;

        private LoginViewModel GetViewModel()
        {
            return new LoginViewModel(this.frameNavigationService, this.userDataSerivce);
        }

        [TestInitialize]
        public void Init()
        {
            userDataSerivce = new MockUsernameDataService();
            frameNavigationService = new MockFrameNavigationService();
        }

        [TestMethod]
        public void Login_GetUserByName()
        {
            //Arrange
            User user = null;
            User expectedUser = userDataSerivce.GetUserByName("Arno Bruynseels");

            //act
            LoginViewModel viewModel = GetViewModel();
            user = userDataSerivce.GetUserByName(viewModel.Username);

            //assert
            Assert.AreEqual(user, expectedUser);
        }
    }
}
