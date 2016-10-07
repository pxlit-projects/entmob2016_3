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
        private ObservableCollection<SuperSensor> sensorTypeList;
        private SuperSensor currentSensorType;
        private ISensorTypeData sensorTypeDataService;

        public event PropertyChangedEventHandler PropertyChanged;
        
        //Contructor
        public OverviewViewModel(IFrameNavigation frameNavagationService, ISensorTypeData sensorTypeDataService)
        {
            this.sensorTypeDataService = sensorTypeDataService;
            this.frameNavagationService = frameNavagationService;

            LoadData();

            LoadCommands();

            Messenger.Default.Register<SuperSensor>(this, OnSensorReceived);            
        }

        //Load all data
        private void LoadData()
        {
            sensorTypeList = sensorTypeDataService.GetAllSensorTypes();
        }

        //Messenger received
        private void OnSensorListReceived(ObservableCollection<SuperSensor> sensorTypes)
        {
            sensorTypeList = sensorTypes;
        }

        //Messenger received
        private void OnSensorReceived(SuperSensor sensorType)
        {
            currentSensorType = sensorType;
        }

        //Load all commands
        private void LoadCommands()
        {
            SpectatorCommand = new CustomCommand(NavigateToSpectate, CanNavigate);
        }

        //Getters and setters
        public ObservableCollection<SuperSensor> SensorTypeList
        {
            get { return sensorTypeList; }
            set
            {
                sensorTypeList = value;
            }
        }

        public SuperSensor CurrentSensorType
        {
            get { return currentSensorType; }
            set
            {
                currentSensorType = value;
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
