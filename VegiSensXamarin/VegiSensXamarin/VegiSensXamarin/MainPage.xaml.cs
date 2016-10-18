using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VegiSensXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Button button = new Button
            {
                Text = "Click Me!",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            button.Clicked += OnButtonClicked;

        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Page page = new SelectVegetable();

            button.Navigation.PushAsync(page);
        }
    }
}
