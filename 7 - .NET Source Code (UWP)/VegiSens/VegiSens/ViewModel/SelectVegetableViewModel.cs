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
using VegiSens.ViewModel;

namespace VegiSens.ViewModel
{
    public class SelectVegetableViewModel : SuperViewModel, INotifyPropertyChanged
    {
        //Properties
        public ICommand SaveCommand { get; set; }
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

            LoadCommands();
        }

        //Load all commands
        private void LoadCommands()
        {
            SpectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
            SaveCommand = new CustomCommand(SaveVegetable, CanNavigate);
        }

        //Quit application
        private void SaveVegetable()
        {

        }

        //Load all data
        private void LoadData()
        {
            currentGrowableItem = growableItemService.GetGrowableItemById(1);
            growableItemList = growableItemService.GetAllGrowableItems();
        }

    }
}
