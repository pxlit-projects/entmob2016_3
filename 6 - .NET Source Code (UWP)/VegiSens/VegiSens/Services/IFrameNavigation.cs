using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace VegiSens.Utility
{
    public interface IFrameNavigation
    {
        void NavigateToFrame(Type frameTypeToNavigate);
    }
}
