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
    public class SelectVegetableViewModel : SuperViewModel, INotifyPropertyChanged
    {
        //Properties
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand updateCommand { get; set; }

        private ObservableCollection<GrowableItem> growableItemList;

        public event PropertyChangedEventHandler PropertyChanged;

        //Getters and setters
        public ObservableCollection<GrowableItem> GrowableItemList
        {
            get { return growableItemList; }
            set
            {
                growableItemList = value;
                RaisePropertyChanged("GrowableItemList");
            }
        }

        public GrowableItem CurrentGrowableItem
        {
            get { return currentGrowableItem; }
            set
            {
                currentGrowableItem = value;
                RaisePropertyChanged("CurrentGrowableItem");
            }
        }

        //INotify implementation
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Contructor
        public SelectVegetableViewModel(IFrameNavigation frameNavagationService, IGrowableItemData growableItemService)
        {
            this.growableItemService = growableItemService;
            this.frameNavagationService = frameNavagationService;

            LoadData();

            Messenger.Default.Register<GrowableItem>(this, OnVegetableReceived);

            LoadCommands();
        }

        //Messenger received
        private void OnVegetableReceived(GrowableItem growableItemReceived)
        {
            this.growableItemList.Add(growableItemReceived);
        }

        //Load all commands
        private void LoadCommands()
        {
            SpectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
            AddCommand = new CustomCommand(NavigateToAddVegetablePage, CanNavigate);
            updateCommand= new CustomCommand(NavigateToUpdateVegetablePage, CanNavigate);
            SaveCommand = new CustomCommand(SaveVegetable, CanNavigate);
        }

        //Navigate to Add Vegetable
        protected void NavigateToAddVegetablePage()
        {
            frameNavagationService.NavigateToFrame(typeof(UpdateVegetable));
        }

        //Navigate to Update Vegetable
        protected void NavigateToUpdateVegetablePage()
        {
            frameNavagationService.NavigateToFrame(typeof(UpdateVegetable));
        }

        //Quit application
        private async void SaveVegetable()
        {
            Messenger.Default.Send<GrowableItem>(currentGrowableItem);

            //Messgae confirmation
            MessageDialog dialog = new MessageDialog("Selected vegetable has been saved!");
            dialog.Title = "Confirmation";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            await dialog.ShowAsync();

        }

        //Load all data
        private void LoadData()
        {
            currentGrowableItem = growableItemService.GetGrowableItemById(1);
            growableItemList = growableItemService.GetAllGrowableItems();
        }

    }
}
