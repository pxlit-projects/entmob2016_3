﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class SpectatorScreenViewModel : SuperViewModel
    {
        //Properties
        public ObservableCollection<SensorType> sensorTypeList { get; set; }
        private SensorType currentSensorType;

        private ISensorTypeData sensorTypeDataService;

        public ICommand TemperatureOverviewCommand { get; set; }
        public ICommand HumidityOverviewCommand { get; set; }
        public ICommand LightOverviewCommand { get; set; }

        //Contructor
        public SpectatorScreenViewModel(IFrameNavigation frameNavagationService, IGrowableItemData growableItemService, ISensorTypeData sensorTypeDataService)
        {
            this.sensorTypeDataService = sensorTypeDataService;
            this.growableItemService = growableItemService;
            this.frameNavagationService = frameNavagationService;

            LoadData();

            LoadCommands();

            Messenger.Default.Register<GrowableItem>(this, OnGrowableItemReceived, "SAVE");
        }

        private void OnGrowableItemReceived(GrowableItem growbaleItem)
        {
            currentGrowableItem = growbaleItem;
        }

        //Load all commands
        private void LoadCommands()
        {
            TemperatureOverviewCommand = new CustomCommand(NavigateToOverviewWithTemperature, CanNavigate);
            HumidityOverviewCommand = new CustomCommand(NavigateToOverviewWithHumidity, CanNavigate);
            LightOverviewCommand = new CustomCommand(NavigateToOverviewWithLight, CanNavigate);

            MainPageCommand = new CustomCommand(NavigateToMainPage, CanNavigate);
            OverviewCommand = new CustomCommand(NavigateToOverview, CanNavigate);

            SelectVegetableCommand = new CustomCommand(NavigateToSelectVegetable, CanNavigate);
        }

        //Load all data
        private void LoadData()
        {
            sensorTypeList = sensorTypeDataService.GetAllSensorTypes();
            currentGrowableItem = growableItemService.GetGrowableItemById(1);
        }

        //Navigate to overview
        public void NavigateToOverview()
        {
            //Standaard Humidity
            currentSensorType = sensorTypeList[0];

            sendDataToMessengerAndNavigate();
        }

        //Navigate to overview
        public void NavigateToOverviewWithTemperature()
        {
            currentSensorType = sensorTypeList[0];

            sendDataToMessengerAndNavigate();
        }

        //Navigate to overview
        public void NavigateToOverviewWithHumidity()
        {
            currentSensorType = sensorTypeList[1];

            sendDataToMessengerAndNavigate();
        }

        //Navigate to overview
        public void NavigateToOverviewWithLight()
        {
            currentSensorType = sensorTypeList[1];

            sendDataToMessengerAndNavigate();

        }

        //Send data to messenger and navigate 
        private void sendDataToMessengerAndNavigate()
        {
            Messenger.Default.Send<SensorType>(currentSensorType);
            frameNavagationService.NavigateToFrame(typeof(Overview));
        }
    }
}
