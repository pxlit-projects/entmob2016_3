using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens;
using VegiSensXamarin.Services;

namespace VegiSens.Test.Mocks
{
    public class MockNavigationService : INavigationService
    {
        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }
    }
}
