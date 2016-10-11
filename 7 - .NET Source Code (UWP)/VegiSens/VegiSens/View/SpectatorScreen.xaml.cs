using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VegiSens.domain;
using System.Threading.Tasks;
using System.Diagnostics;

// Required APIs to use Bluetooth GATT
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

// Required APIs to use built in GUIDs
using Windows.Devices.Enumeration;

// Required APIs for buffer manipulation & async operations
using Windows.Storage.Streams;
using System.Text;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI;

// Disable warning "...execution of the current method continues before the call is completed..."
#pragma warning disable 4014

// Disable warning to "consider using the 'await' operator to await non-blocking API calls"
#pragma warning disable 1998

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VegiSens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpectatorScreen : Page
    { 
    private GattDeviceService[] serviceList = new GattDeviceService[8];
    private GattCharacteristic[] activeCharacteristics = new GattCharacteristic[8];

    const int NUM_SENSORS = 8;
    const int IR_SENSOR = 0;
    const int HUMIDITY = 2;
    const int LUXOMETER = 7;

    const string SENSOR_GUID_PREFIX = "F000AA";
    const string SENSOR_GUID_SUFFFIX = "0-0451-4000-B000-000000000000";
    const string SENSOR_NOTIFICATION_GUID_SUFFFIX = "1-0451-4000-B000-000000000000";
    const string SENSOR_ENABLE_GUID_SUFFFIX = "2-0451-4000-B000-000000000000";
    const string SENSOR_PERIOD_GUID_SUFFFIX = "3-0451-4000-B000-000000000000";

    const string LUXOMETER_GUID_STR = "F000AA70-0451-4000-B000-000000000000";
    readonly Guid LUXOMETER_GUID = new Guid(LUXOMETER_GUID_STR);

    readonly Guid BAROMETER_CONFIGURATION_GUID = new Guid("F000AA42-0451-4000-B000-000000000000");
    readonly Guid BAROMETER_CALIBRATION_GUID = new Guid("F000AA43-0451-4000-B000-000000000000");

    readonly Guid LUXOMETER_CONFIGURATION_GUID = new Guid("F000AA72-0451-4000-B000-000000000000");
    readonly Guid LUXOMETER_CALIBRATION_GUID = new Guid("F000AA73-0451-4000-B000-000000000000");


    private DeviceWatcher deviceWatcher = null;
    private DeviceInformationDisplay DeviceInfoConnected = null;

    private TypedEventHandler<DeviceWatcher, DeviceInformation> handlerAdded = null;
    private TypedEventHandler<DeviceWatcher, DeviceInformationUpdate> handlerUpdated = null;
    private TypedEventHandler<DeviceWatcher, DeviceInformationUpdate> handlerRemoved = null;
    private TypedEventHandler<DeviceWatcher, Object> handlerEnumCompleted = null;

    private DeviceWatcher blewatcher = null;
    private TypedEventHandler<DeviceWatcher, DeviceInformation> OnBLEAdded = null;
    private TypedEventHandler<DeviceWatcher, DeviceInformationUpdate> OnBLEUpdated = null;
    private TypedEventHandler<DeviceWatcher, DeviceInformationUpdate> OnBLERemoved = null;

    TaskCompletionSource<string> providePinTaskSrc;
    TaskCompletionSource<bool> confirmPinTaskSrc;


    public ObservableCollection<DeviceInformationDisplay> ResultCollection
    {
        get;
        private set;
    }
    public SpectatorScreen()
    {
        this.InitializeComponent();

        UserOut.Text = "Searching for Bluetooth LE Devices...";
        resultsListView.IsEnabled = false;
        PairButton.IsEnabled = false;

        ResultCollection = new ObservableCollection<DeviceInformationDisplay>();

       resultsListView.ItemsSource = ResultCollection;
        DataContext = this;
        //Start Watcher for pairable/paired devices
        StartWatcher();
    }

    ~SpectatorScreen()
    {
        StopWatcher();
    }

    private void StartWatcher()
    {
        //ZOEKEN EN FILTERERN OP SENSORTAG 
        string aqsFilter;

        ResultCollection.Clear();

        // Request the IsPaired property so we can display the paired status in the UI
        string[] requestedProperties = { "System.Devices.Aep.IsPaired" };

        //for   es
        aqsFilter = "System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\"";

        deviceWatcher = DeviceInformation.CreateWatcher(
            aqsFilter,
            requestedProperties,
            DeviceInformationKind.AssociationEndpoint
            );

        // Hook up handlers for the watcher events before starting the watcher

        handlerAdded = async (watcher, deviceInfo) =>
        {
            // Since we have the collection databound to a UI element, we need to update the collection on the UI thread.
            this.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                Debug.WriteLine("Watcher Add: " + deviceInfo.Id);
                ResultCollection.Add(new DeviceInformationDisplay(deviceInfo));
                UpdatePairingButtons();
            });
        };
        deviceWatcher.Added += handlerAdded;

        handlerUpdated = async (watcher, deviceInfoUpdate) =>
        {
            // Since we have the collection databound to a UI element, we need to update the collection on the UI thread.
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                Debug.WriteLine("Watcher Update: " + deviceInfoUpdate.Id);
                // Find the corresponding updated DeviceInformation in the collection and pass the update object
                // to the Update method of the existing DeviceInformation. This automatically updates the object
                // for us.
                foreach (DeviceInformationDisplay deviceInfoDisp in ResultCollection)
                {
                    if (deviceInfoDisp.Id == deviceInfoUpdate.Id)
                    {
                        deviceInfoDisp.Update(deviceInfoUpdate);
                        break;
                    }
                }
            });
        };

        deviceWatcher.Updated += handlerUpdated;


        handlerRemoved = async (watcher, deviceInfoUpdate) =>
        {
            // Since we have the collection databound to a UI element, we need to update the collection on the UI thread.
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                Debug.WriteLine("Watcher Remove: " + deviceInfoUpdate.Id);
                // Find the corresponding DeviceInformation in the collection and remove it
                foreach (DeviceInformationDisplay deviceInfoDisp in ResultCollection)
                {
                    if (deviceInfoDisp.Id == deviceInfoUpdate.Id)
                    {
                        ResultCollection.Remove(deviceInfoDisp);
                        UpdatePairingButtons();
                        if (ResultCollection.Count == 0)
                        {
                            UserOut.Text = "Searching for Bluetooth LE Devices...";
                        }
                        break;
                    }
                }
            });
        };
        deviceWatcher.Removed += handlerRemoved;

        handlerEnumCompleted = async (watcher, obj) =>
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                Debug.WriteLine($"Found {ResultCollection.Count} Bluetooth LE Devices");

                if (ResultCollection.Count > 0)
                {
                    UserOut.Text = "Select a device for pairing";
                }
                else
                {
                    UserOut.Text = "No Bluetooth LE Devices found.";
                }
                UpdatePairingButtons();
            });
        };

        deviceWatcher.EnumerationCompleted += handlerEnumCompleted;

        deviceWatcher.Start();
    }

    private void StopWatcher()
    {
        if (null != deviceWatcher)
        {
            // First unhook all event handlers except the stopped handler. This ensures our
            // event handlers don't get called after stop, as stop won't block for any "in flight" 
            // event handler calls.  We leave the stopped handler as it's guaranteed to only be called
            // once and we'll use it to know when the query is completely stopped. 
            deviceWatcher.Added -= handlerAdded;
            deviceWatcher.Updated -= handlerUpdated;
            deviceWatcher.Removed -= handlerRemoved;
            deviceWatcher.EnumerationCompleted -= handlerEnumCompleted;

            if (DeviceWatcherStatus.Started == deviceWatcher.Status ||
                DeviceWatcherStatus.EnumerationCompleted == deviceWatcher.Status)
            {
                deviceWatcher.Stop();
            }
        }
    }

    private void StartBLEWatcher()
    {
        int discoveredServices = 0;
        // Hook up handlers for the watcher events before starting the watcher
        OnBLEAdded = async (watcher, deviceInfo) =>
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
            {
                Debug.WriteLine("OnBLEAdded: " + deviceInfo.Id);
                GattDeviceService service = await GattDeviceService.FromIdAsync(deviceInfo.Id);

                if (service != null)
                {
                    int sensorIdx = -1;
                    string svcGuid = service.Uuid.ToString().ToUpper();
                    Debug.WriteLine("Found Service: " + svcGuid);

                    // Add this service to the list if it conforms to the TI-GUID pattern for most sensors
                    if (svcGuid.StartsWith(SENSOR_GUID_PREFIX))
                    {
                        // The character at this position indicates the index into the serviceList 
                        // container that we want to save this service to.  The rest of this program
                        // assumes that specific sensor types are at specific indexes in this array
                        sensorIdx = svcGuid[6] - '0';
                    }
                    // otherwise, if this is the GUID for the KEYS, then handle it special
                    else if (svcGuid == LUXOMETER_GUID_STR)
                    {
                        sensorIdx = LUXOMETER;
                    }
                    // If the index is legal and a service hasn't already been cached, then
                    // cache this service in our serviceList
                    if (((sensorIdx >= 0) && (sensorIdx <= LUXOMETER)))
                    {
                        serviceList[sensorIdx] = service;
                        await enableSensor(sensorIdx);
                        System.Threading.Interlocked.Increment(ref discoveredServices);
                    }

                    // When all sensors have been discovered, notify the user
                    if (discoveredServices == NUM_SENSORS)
                    {
                        //SensorList.IsEnabled = true;
                        //DisableButton.IsEnabled = true;
                        //EnableButton.IsEnabled = true;
                        discoveredServices = 0;
                        UserOut.Text = "Sensors on!";
                    }
                }
            });
        };


        OnBLEUpdated = async (watcher, deviceInfoUpdate) =>
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                Debug.WriteLine($"OnBLEUpdated: {deviceInfoUpdate.Id}");
            });
        };


        OnBLERemoved = async (watcher, deviceInfoUpdate) =>
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                Debug.WriteLine("OnBLERemoved");

            });
        };

        string aqs = "";

        for (int i = 0; i < NUM_SENSORS; i++)
        {
            Guid BLE_GUID;

            if (i < 3)
                BLE_GUID = new Guid(SENSOR_GUID_PREFIX + i + SENSOR_GUID_SUFFFIX);
            else
                BLE_GUID = LUXOMETER_GUID;

            aqs += "(" + GattDeviceService.GetDeviceSelectorFromUuid(BLE_GUID) + ")";

            if (i < NUM_SENSORS - 1)
            {
                aqs += " OR ";
            }
        }


        blewatcher = DeviceInformation.CreateWatcher(aqs);
        blewatcher.Added += OnBLEAdded;
        blewatcher.Updated += OnBLEUpdated;
        blewatcher.Removed += OnBLERemoved;
        blewatcher.Start();
    }

    private void StopBLEWatcher()
    {
        if (null != blewatcher)
        {
            blewatcher.Added -= OnBLEAdded;
            blewatcher.Updated -= OnBLEUpdated;
            blewatcher.Removed -= OnBLERemoved;

            if (DeviceWatcherStatus.Started == blewatcher.Status ||
                DeviceWatcherStatus.EnumerationCompleted == blewatcher.Status)
            {
                blewatcher.Stop();
            }
        }
    }

    private async void PairButton_Click(object sender, RoutedEventArgs e)
    {
        DeviceInformationDisplay deviceInfoDisp = resultsListView.SelectedItem as DeviceInformationDisplay;

        if (deviceInfoDisp != null)
        {
            PairButton.IsEnabled = false;
            bool paired = true;
            if (deviceInfoDisp.IsPaired != true)
            {
                paired = false;
                DevicePairingKinds ceremoniesSelected = DevicePairingKinds.ConfirmOnly | DevicePairingKinds.DisplayPin | DevicePairingKinds.ProvidePin | DevicePairingKinds.ConfirmPinMatch;
                DevicePairingProtectionLevel protectionLevel = DevicePairingProtectionLevel.Default;

                // Specify custom pairing with all ceremony types and protection level EncryptionAndAuthentication
                DeviceInformationCustomPairing customPairing = deviceInfoDisp.DeviceInformation.Pairing.Custom;

                customPairing.PairingRequested += PairingRequestedHandler;
                DevicePairingResult result = await customPairing.PairAsync(ceremoniesSelected, protectionLevel);

                customPairing.PairingRequested -= PairingRequestedHandler;

                if (result.Status == DevicePairingResultStatus.Paired)
                {
                    paired = true;
                }
                else
                {
                    UserOut.Text = "Pairing Failed " + result.Status.ToString();
                }
            }

            if (paired)
            {
                // device is paired, set up the sensor Tag            
                UserOut.Text = "Setting up SensorTag";

                DeviceInfoConnected = deviceInfoDisp;

                //Start watcher for Bluetooth LE Services
                StartBLEWatcher();
            }
            UpdatePairingButtons();
        }
    }

    private async void PairingRequestedHandler(
         DeviceInformationCustomPairing sender,
         DevicePairingRequestedEventArgs args)
    {
        switch (args.PairingKind)
        {
            case DevicePairingKinds.ConfirmOnly:
                // Windows itself will pop the confirmation dialog as part of "consent" if this is running on Desktop or Mobile
                // If this is an App for 'Windows IoT Core' where there is no Windows Consent UX, you may want to provide your own confirmation.
                args.Accept();
                break;

            case DevicePairingKinds.DisplayPin:
                // We just show the PIN on this side. The ceremony is actually completed when the user enters the PIN
                // on the target device. We automatically except here since we can't really "cancel" the operation
                // from this side.
                args.Accept();

                // No need for a deferral since we don't need any decision from the user
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ShowPairingPanel(
                        "Please enter this PIN on the device you are pairing with: " + args.Pin,
                        args.PairingKind);

                });
                break;

            case DevicePairingKinds.ProvidePin:
                // A PIN may be shown on the target device and the user needs to enter the matching PIN on 
                // this Windows device. Get a deferral so we can perform the async request to the user.
                var collectPinDeferral = args.GetDeferral();

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    string pin = await GetPinFromUserAsync();
                    if (!string.IsNullOrEmpty(pin))
                    {
                        args.Accept(pin);
                    }

                    collectPinDeferral.Complete();
                });
                break;

            case DevicePairingKinds.ConfirmPinMatch:
                // We show the PIN here and the user responds with whether the PIN matches what they see
                // on the target device. Response comes back and we set it on the PinComparePairingRequestedData
                // then complete the deferral.
                var displayMessageDeferral = args.GetDeferral();

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    bool accept = await GetUserConfirmationAsync(args.Pin);
                    if (accept)
                    {
                        args.Accept();
                    }

                    displayMessageDeferral.Complete();
                });
                break;
        }
    }

    private void ShowPairingPanel(string text, DevicePairingKinds pairingKind)
    {
            pairingPanel.Visibility = Visibility.Collapsed;
            pinEntryTextBox.Visibility = Visibility.Collapsed;
            okButton.Visibility = Visibility.Collapsed;
            yesButton.Visibility = Visibility.Collapsed;
            noButton.Visibility = Visibility.Collapsed;
            pairingTextBlock.Text = text;

            switch (pairingKind)
        {
            case DevicePairingKinds.ConfirmOnly:
            case DevicePairingKinds.DisplayPin:
                // Don't need any buttons
                break;
            case DevicePairingKinds.ProvidePin:
                    pinEntryTextBox.Text = "";
                    pinEntryTextBox.Visibility = Visibility.Visible;
                    okButton.Visibility = Visibility.Visible;
                    break;
            case DevicePairingKinds.ConfirmPinMatch:
                    yesButton.Visibility = Visibility.Visible;
                    noButton.Visibility = Visibility.Visible;
                    break;
        }

        //pairingPanel.Visibility = Visibility.Visible;
    }

    private void HidePairingPanel()
    {
        //pairingPanel.Visibility = Visibility.Collapsed;
        //pairingTextBlock.Text = "";
    }

    private async Task<string> GetPinFromUserAsync()
    {
        HidePairingPanel();
        CompleteProvidePinTask(); // Abandon any previous pin request.

        ShowPairingPanel(
            "Please enter the PIN shown on the device you're pairing with",
            DevicePairingKinds.ProvidePin);

        providePinTaskSrc = new TaskCompletionSource<string>();

        return await providePinTaskSrc.Task;
    }

    private void CompleteProvidePinTask(string pin = null)
    {
        if (providePinTaskSrc != null)
        {
            providePinTaskSrc.SetResult(pin);
            providePinTaskSrc = null;
        }
    }

    private async Task<bool> GetUserConfirmationAsync(string pin)
    {
        HidePairingPanel();
        CompleteConfirmPinTask(false); // Abandon any previous request.

        ShowPairingPanel(
            "Does the following PIN match the one shown on the device you are pairing?: " + pin,
            DevicePairingKinds.ConfirmPinMatch);

        confirmPinTaskSrc = new TaskCompletionSource<bool>();

        return await confirmPinTaskSrc.Task;
    }

    private void CompleteConfirmPinTask(bool accept)
    {
        if (confirmPinTaskSrc != null)
        {
            confirmPinTaskSrc.SetResult(accept);
            confirmPinTaskSrc = null;
        }
    }

    private async void UnpairButton_Click(object sender, RoutedEventArgs e)
    {
        DeviceInformationDisplay deviceInfoDisp = resultsListView.SelectedItem as DeviceInformationDisplay;
        Debug.WriteLine("Unpair");

        UnpairButton.IsEnabled = false;
        //SensorList.IsEnabled = false;
        //EnableButton.IsEnabled = false;
        //DisableButton.IsEnabled = false;
        DeviceInfoConnected = null;

        Debug.WriteLine("Disable Sensors");
        for (int i = 0; i < NUM_SENSORS; i++)
        {
            if (serviceList[i] != null)
            {
                await disableSensor(i);
            }
        }

        Debug.WriteLine("UnpairAsync");
        try
        {
            DeviceUnpairingResult dupr = await deviceInfoDisp.DeviceInformation.Pairing.UnpairAsync();
            string unpairResult = $"Unpairing result = {dupr.Status}";
            Debug.WriteLine(unpairResult);
            UserOut.Text = unpairResult;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Unpair exception = " + ex.Message);
        }

        for (int i = 0; i < NUM_SENSORS; i++)
        {
            serviceList[i] = null;
        }

        UpdatePairingButtons();
    }

    private void UpdatePairingButtons()
    {
        var deviceInfoDisp = (DeviceInformationDisplay)resultsListView.SelectedItem;
        bool bSelectableDevices = (resultsListView.Items.Count > 0);

        // If something on the list of bluetooth devices is selected
        if ((null != deviceInfoDisp) && (deviceWatcher.Status == DeviceWatcherStatus.EnumerationCompleted))
        {
            bool bIsConnected = (DeviceInfoConnected != null);

            // If we're paired and this app has connected to the device then allow the user to unpair, 
            // from the selected device, but do not allow the use to pair with or select some other device.
            if ((deviceInfoDisp.DeviceInformation.Pairing.IsPaired) && (bIsConnected))
            {
                resultsListView.IsEnabled = false;
                UnpairButton.IsEnabled = true;
                PairButton.IsEnabled = false;
            }
            // Otherwise, we're either unpaired OR we are paired to something but this app hasn't connected to it
            // so allow the user to select one of the BLE devices from the list
            else
            {
                resultsListView.IsEnabled = bSelectableDevices;
                UnpairButton.IsEnabled = false;
                PairButton.IsEnabled = bSelectableDevices;
            }
        }
        // otherwise there are no devices selected by the user, so allow the user to select something
        // so long as there are items on the list to select
        else
        {
            resultsListView.IsEnabled = bSelectableDevices;
            PairButton.IsEnabled = false;
        }
    }

    private void yesButton_Click(object sender, RoutedEventArgs e)
    {
        CompleteConfirmPinTask(true);
        HidePairingPanel();
    }

    private void noButton_Click(object sender, RoutedEventArgs e)
    {
        CompleteConfirmPinTask(false);
        HidePairingPanel();
    }

    private void okButton_Click(object sender, RoutedEventArgs e)
    {
        // OK button is only used for the ProvidePin scenario
        //CompleteProvidePinTask(pinEntryTextBox.Text);
        HidePairingPanel();
    }

    private void EnableButton_Click(object sender, RoutedEventArgs e)
    {
        //if (SensorList.SelectedIndex >= 0)
        //{
        //    enableSensor(SensorList.SelectedIndex);
        //}
    }

    private void DisableButton_Click(object sender, RoutedEventArgs e)
    {
        //if (SensorList.SelectedIndex >= 0)
        //{
        //    disableSensor(SensorList.SelectedIndex);
        //}
    }

    private void ResultsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdatePairingButtons();
    }

    private async Task enableSensor(int sensor)
    {
        Debug.WriteLine("Begin enable sensor: " + sensor.ToString());
        GattDeviceService gattService = serviceList[sensor];
        if (gattService != null)
        {
            // Turn on notifications
            IReadOnlyList<GattCharacteristic> characteristicList;
            if (sensor >= 0 && sensor <= 2)
                characteristicList = gattService.GetCharacteristics(new Guid(SENSOR_GUID_PREFIX + sensor + SENSOR_NOTIFICATION_GUID_SUFFFIX));
            else
                characteristicList = gattService.GetCharacteristics(LUXOMETER_CONFIGURATION_GUID);

            if (characteristicList != null)
            {
                GattCharacteristic characteristic = characteristicList[0];

                if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    switch (sensor)
                    {
                        case (IR_SENSOR):
                            characteristic.ValueChanged += tempChanged;
                            temperatureTitleTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                            break;
                        case (HUMIDITY):
                            characteristic.ValueChanged += humidChanged;
                            humidityTitleTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                            break;
                        case (LUXOMETER):
                            characteristic.ValueChanged += luxChanged;
                            //BaroTitle.Foreground = new SolidColorBrush(Colors.Green);
                            break;
                        default:
                            break;
                    }

                    // Save a reference to each active characteristic, so that handlers do not get prematurely killed
                    activeCharacteristics[sensor] = characteristic;

                    // Set the notify enable flag
                    await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                }
            }

            // Turn on sensor
            if (sensor >= 0 && sensor <= 7)
            {
                characteristicList = gattService.GetCharacteristics(new Guid(SENSOR_GUID_PREFIX + sensor + SENSOR_ENABLE_GUID_SUFFFIX));
                if (characteristicList != null)
                {
                    GattCharacteristic characteristic = characteristicList[0];
                    if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write))
                    {
                        var writer = new Windows.Storage.Streams.DataWriter();
                        // Special value for Gyroscope to enable all 3 axes
                        writer.WriteByte((Byte)0x01);

                        await characteristic.WriteValueAsync(writer.DetachBuffer());
                    }
                }
            }
        }
        Debug.WriteLine("End enable sensor: " + sensor.ToString());

    }

    private async Task disableSensor(int sensor)
    {
        Debug.WriteLine("Begin disable of sensor: " + sensor.ToString());
        GattDeviceService gattService = serviceList[sensor];
        if (gattService != null)
        {
            // Disable notifications
            IReadOnlyList<GattCharacteristic> characteristicList;
            if (sensor >= 0 && sensor <= 2)
                characteristicList = gattService.GetCharacteristics(new Guid(SENSOR_GUID_PREFIX + sensor + SENSOR_NOTIFICATION_GUID_SUFFFIX));
            else
                characteristicList = gattService.GetCharacteristics(LUXOMETER_CONFIGURATION_GUID);

            if (characteristicList != null)
            {
                GattCharacteristic characteristic = characteristicList[0];
                if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    GattCommunicationStatus status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                }
            }
        }

        switch (sensor)
        {
            case (IR_SENSOR):
                //IRTitle.Foreground = new SolidColorBrush(Colors.White);
                break;
            case (HUMIDITY):
                //HumidTitle.Foreground = new SolidColorBrush(Colors.White);
                break;
            case (LUXOMETER):
                //MagnoTitle.Foreground = new SolidColorBrush(Colors.White);
                break;
            default:
                break;
        }
        activeCharacteristics[sensor] = null;
        Debug.WriteLine("End disable for sensor: " + sensor.ToString());

    }

    async void tempChanged(GattCharacteristic sender, GattValueChangedEventArgs eventArgs)
    {
        byte[] bArray = new byte[eventArgs.CharacteristicValue.Length];
        DataReader.FromBuffer(eventArgs.CharacteristicValue).ReadBytes(bArray);
        double AmbTemp = (double)(((UInt16)bArray[3] << 8) + (UInt16)bArray[2]);
        AmbTemp /= 128.0;

        Int16 temp = (Int16)(((UInt16)bArray[1] << 8) + (UInt16)bArray[0]);
        double Vobj2 = (double)temp;
        Vobj2 *= 0.00000015625;
        double Tdie = AmbTemp + 273.15;

        const double S0 = 5.593E-14;            // Calibration factor
        const double a1 = 1.75E-3;
        const double a2 = -1.678E-5;
        const double b0 = -2.94E-5;
        const double b1 = -5.7E-7;
        const double b2 = 4.63E-9;
        const double c2 = 13.4;
        const double Tref = 298.15;

        double S = S0 * (1 + a1 * (Tdie - Tref) + a2 * Math.Pow((Tdie - Tref), 2));
        double Vos = b0 + b1 * (Tdie - Tref) + b2 * Math.Pow((Tdie - Tref), 2);
        double fObj = (Vobj2 - Vos) + c2 * Math.Pow((Vobj2 - Vos), 2);
        double tObj = Math.Pow(Math.Pow(Tdie, 4) + (fObj / S), 0.25);

        tObj = (tObj - 273.15);
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            temperatureValueTextBlock.Text = string.Format("Chip:\t{0:0.0####}", AmbTemp);
            //temperatureValueTextBlock.Text = string.Format("IR:  \t{0:0.0####}", tObj);
        });
    }

    async void humidChanged(GattCharacteristic sender, GattValueChangedEventArgs eventArgs)
    {
        byte[] bArray = new byte[eventArgs.CharacteristicValue.Length];
        DataReader.FromBuffer(eventArgs.CharacteristicValue).ReadBytes(bArray);

        double humidity = (double)((((UInt16)bArray[1] << 8) + (UInt16)bArray[0]) & ~0x0003);
        humidity = (-6.0 + 125.0 / 65536 * humidity); // RH= -6 + 125 * SRH/2^16
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            humidityValueTextBlock.Text = humidity.ToString();
        });
    }

    async void luxChanged(GattCharacteristic sender, GattValueChangedEventArgs eventArgs)
    {

        //BaroOut.Text = "lol - ";

        //byte[] bArray = new byte[eventArgs.CharacteristicValue.Length];
        //DataReader.FromBuffer(eventArgs.CharacteristicValue).ReadBytes(bArray);

        //double lux = (double)((UInt16)bArray[1]);
        //double e = (double)((UInt16)bArray[1] >> 12);
        //lux = lux * (0.01 * Math.Pow(2.0, e)); // RH= -6 + 125 * SRH/2^16
        //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //{
        //    BaroOut.Text = lux.ToString();
        //});
    }
}
}

