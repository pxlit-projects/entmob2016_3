using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSens.domain;
using VegiSens.Services;
using VegiSens.Utility;
using VegiSens.View;
using VegiSens.ViewModel;
using Windows.UI.Popups;

namespace VegiSens.ViewModel
{
    public class AddVegetableViewModel : SuperViewModel
    {
        //Properties
        public ICommand AddVegetableCommand { get; set; }

        //Vegetable Information
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string MinHumidity { get; set; }
        public string MaxHumidity { get; set; }
        public string MinTemperature { get; set; }
        public string MaxTemperature { get; set; }

        //Contructor
        public AddVegetableViewModel(IFrameNavigation frameNavagationService, IGrowableItemData growableItemService)
        {
            this.growableItemService = growableItemService;
            this.frameNavagationService = frameNavagationService;
                
            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            SelectVegetableCommand = new CustomCommand(NavigateToSelectVegetable, CanNavigate);
            AddVegetableCommand = new CustomCommand(AddVegetableAndNavigate, CanNavigate);
        }


        //Quit application
        private async void AddVegetableAndNavigate()
        {
            Humidity humidityToAdd = new Humidity();

            humidityToAdd.MaxHumidity = Convert.ToDouble(this.MaxHumidity);
            humidityToAdd.MinHumidity = Convert.ToDouble(this.MinHumidity);

            Temperature temperatureToAdd = new Temperature();

            temperatureToAdd.MaxTemperature = Convert.ToDouble(this.MaxTemperature);
            temperatureToAdd.MinTemperature = Convert.ToDouble(this.MinTemperature);

            GrowableItem growbleItemToAdd = new GrowableItem();

            growbleItemToAdd.name = this.Name;
            growbleItemToAdd.Description = this.Description;
            growbleItemToAdd.Image = this.ImagePath;
            growbleItemToAdd.Temperature = temperatureToAdd;
            growbleItemToAdd.Humidity = humidityToAdd;

            //Messgae confirmation
            MessageDialog dialog = new MessageDialog("Vegetable has been added!");
            dialog.Title = "Confirmation";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            await dialog.ShowAsync();

            growableItemService.AddVegetableITem(growbleItemToAdd);

            //frameNavagationService.NavigateToFrame(typeof(SelectVegetable));
        }
    }
}
