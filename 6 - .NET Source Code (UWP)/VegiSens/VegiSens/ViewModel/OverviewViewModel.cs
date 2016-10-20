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
    public class OverviewViewModel : SuperViewModel, INotifyPropertyChanged
    {
        //Properties
        private ObservableCollection<SensorType> sensorTypeList;
        private SensorType currentSensorType;
        private ISensorTypeData sensorTypeDataService;

        public event PropertyChangedEventHandler PropertyChanged;
        
        //Contructor
        public OverviewViewModel(IFrameNavigation frameNavagationService, ISensorTypeData sensorTypeDataService)
        {
            this.sensorTypeDataService = sensorTypeDataService;
            this.frameNavagationService = frameNavagationService;

            LoadData();

            LoadCommands();

            Messenger.Default.Register<SensorType>(this, OnSensorReceived);            
        }

        //Load all data
        private void LoadData()
        {
            sensorTypeList = sensorTypeDataService.GetAllSensorTypes();
        }

        //Messenger received
        private void OnSensorReceived(SensorType sensorType)
        {
            currentSensorType = sensorType;
            currentSensorType.SetValues(currentSensorType);
            currentSensorType.SetDates(currentSensorType);
        }

        //Load all commands
        private void LoadCommands()
        {
            SpectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
        }

        //Getters and setters
        public ObservableCollection<SensorType> SensorTypeList
        {
            get { return sensorTypeList; }
            set
            {
                sensorTypeList = value;
            }
        }

        public SensorType CurrentSensorType
        {
            get { return currentSensorType; }
            set
            {
                currentSensorType = value;
                currentSensorType.SetValues(currentSensorType);
                currentSensorType.SetDates(currentSensorType);
                RaisePropertyChanged("CurrentSensorType");
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
    }
}
