using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Locator;
using Xamarin.Forms;

namespace VegiSensXamarin
{
    public partial class GroentenMenu : ContentPage
    {
        public GroentenMenu()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.GroentenMenuViewModel;
        }
    }
}
