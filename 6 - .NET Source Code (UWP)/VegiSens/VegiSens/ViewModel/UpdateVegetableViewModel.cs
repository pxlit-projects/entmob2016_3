using System;
using System.Windows.Input;
using VegiSens.domain;
using VegiSens.Services;
using VegiSens.Utility;
using Windows.UI.Popups;

namespace VegiSens.ViewModel
{
    public class UpdateVegetableViewModel : SuperViewModel
    {
        //Properties
        public ICommand UpdateVegetableCommand { get; set; }

        //Vegetable Information
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string MinHumidity { get; set; }
        public string MaxHumidity { get; set; }
        public string MinTemperature { get; set; }
        public string MaxTemperature { get; set; }

        //Contructor
        public UpdateVegetableViewModel(IFrameNavigation frameNavagationService, IGrowableItemData growableItemService)
        {
            this.growableItemService = growableItemService;
            this.frameNavagationService = frameNavagationService;

            LoadCommands();

            Messenger.Default.Register<GrowableItem>(this, OnVegetableReceived);
        }

        //Messenger received
        private void OnVegetableReceived(GrowableItem growableItemReceived)
        {
           currentGrowableItem = growableItemReceived;
        }

        //Load all commands
        private void LoadCommands()
        {
            SelectVegetableCommand = new CustomCommand(NavigateToSelectVegetable, CanNavigate);
            UpdateVegetableCommand = new CustomCommand(UpdateVegetableAndNavigate, CanNavigate);
        }

        public GrowableItem CurrentGrowableItem
        {
            get { return currentGrowableItem; }
            set { currentGrowableItem = value; }
        }

        private async void UpdateVegetableAndNavigate()
        {
            Humidity humidityToAdd = new Humidity();

            humidityToAdd.HumidityId = currentGrowableItem.Humidity.HumidityId;
            humidityToAdd.MaxHumidity = Convert.ToDouble(this.MaxHumidity);
            humidityToAdd.MinHumidity = Convert.ToDouble(this.MinHumidity);

            Temperature temperatureToAdd = new Temperature();

            temperatureToAdd.temperatureId = currentGrowableItem.Temperature.temperatureId;
            temperatureToAdd.MaxTemperature = Convert.ToDouble(this.MaxTemperature);
            temperatureToAdd.MinTemperature = Convert.ToDouble(this.MinTemperature);

            GrowableItem growbleItemToUpdate = new GrowableItem();

            growbleItemToUpdate.GrowableItemID = currentGrowableItem.GrowableItemID;
            growbleItemToUpdate.Name = this.Name;
            growbleItemToUpdate.Description = this.Description;
            growbleItemToUpdate.Image = this.ImagePath;
            growbleItemToUpdate.Temperature = temperatureToAdd;
            growbleItemToUpdate.Humidity = humidityToAdd;

            //Messgae confirmation
            MessageDialog dialog = new MessageDialog("Vegetable has been updated!");
            dialog.Title = "Confirmation";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            await dialog.ShowAsync();

            growableItemService.UpdateVegetableItem(growbleItemToUpdate);

            //Send message for other pages to register the new vegetable
            Messenger.Default.Send<GrowableItem>(growbleItemToUpdate);

            frameNavagationService.NavigateToFrame(typeof(SelectVegetable));
        }
    }
}
