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
    public sealed partial class AddVegetable : Page
    {
        public AddVegetable()
        {
            this.InitializeComponent();
        }

        //Get the data from textboxes
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ((AddVegetableViewModel)this.DataContext).Name = nameTextBox.Text;
            ((AddVegetableViewModel)this.DataContext).Description = descriptionTextBox.Text;
            ((AddVegetableViewModel)this.DataContext).ImagePath = imageTextBox.Text;
            ((AddVegetableViewModel)this.DataContext).MinHumidity = humMinTextBox.Text;
            ((AddVegetableViewModel)this.DataContext).MaxHumidity = humMaxTextBox.Text;
            ((AddVegetableViewModel)this.DataContext).MinTemperature = tempMinTextBox.Text;
            ((AddVegetableViewModel)this.DataContext).MaxTemperature = tempMaxTextBox.Text;
        }
    }
}
