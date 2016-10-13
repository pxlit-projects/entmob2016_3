using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.Utility;

namespace VegiSens.Test.Mocks
{
    public class MockFrameNavigationService : IFrameNavigation
    {
        //Contructor
        public MockFrameNavigationService()
        {

        }

        public void NavigateToFrame(Type frameTypeToNavigate)
        {
            throw new NotImplementedException();
        }
    }
}
