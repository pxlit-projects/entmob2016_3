using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Locator;
using VegiSensXamarin.Services;
using VegiSensXamarin.ViewModel;
using Xamarin.Forms;

namespace VegiSensXamarin
{
    public partial class GroentenDetail : ContentPage
    {
        public GroentenDetail()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.GroentenMenuViewModel;

        }
    }
}
