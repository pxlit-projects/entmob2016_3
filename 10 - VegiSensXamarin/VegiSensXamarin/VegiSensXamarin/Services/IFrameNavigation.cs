using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSensXamarin.Services
{
    public interface IFrameNavigation
    {
        void NavigateToFrame(Type frameTypeToNavigate);
    }
}
