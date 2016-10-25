using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VegiSens.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VegiSens.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateVegetable : Page
    {
        public UpdateVegetable()
        {
            this.InitializeComponent();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            ((UpdateVegetableViewModel)this.DataContext).Name = nameTextBox.Text;
            ((UpdateVegetableViewModel)this.DataContext).Description = descriptionTextBox.Text;
            ((UpdateVegetableViewModel)this.DataContext).ImagePath = imageTextBox.Text;
            ((UpdateVegetableViewModel)this.DataContext).MinHumidity = humMinTextBox.Text;
            ((UpdateVegetableViewModel)this.DataContext).MaxHumidity = humMaxTextBox.Text;
            ((UpdateVegetableViewModel)this.DataContext).MinTemperature = tempMinTextBox.Text;
            ((UpdateVegetableViewModel)this.DataContext).MaxTemperature = tempMaxTextBox.Text;
        }
    }
}
