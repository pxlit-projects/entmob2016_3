using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VegiSensDomain;
using VegiSensXamarin.Services;
using Xamarin.Forms;
using VegiSensXamarin.Utility;
using XLabs.Forms.Controls;

namespace VegiSensXamarin.ViewModel
{
    public class GroentenMenuViewModel : ViewModelBase
    {
        private IGrowableItemDataService growableDataservice;
        private INavigationService navigationService;

        public ObservableCollection<GrowableItem> GrowableItemListRevceived { get; set; }
        public ObservableCollection<GrowableItem> GrowableItemListToSend { get; set; }

        public ICommand ViewDetailCommand { get; set; }


        public GroentenMenuViewModel(INavigationService navigationService, IGrowableItemDataService growableDataservice)
        {
            this.growableDataservice = growableDataservice;
            this.navigationService = navigationService;

            GrowableItemListRevceived = new ObservableCollection<GrowableItem>();
            GrowableItemListToSend = new ObservableCollection<GrowableItem>();

            InitializeCommands();
            loadData();
        }

        private void InitializeCommands()
        {
            ViewDetailCommand = new Command(
            (parameter) =>
            {
                    switch (parameter.ToString())
                    {
                        case "Red Tomato":
                            navigateToDetailview(0);
                            break;
                        case "Strawberry":
                            navigateToDetailview(1);
                            break;
                        case "Red cabbage":
                            navigateToDetailview(2);
                            break;
                        case "Potato":
                            navigateToDetailview(3);
                            break;
                        case "Garlic":
                            navigateToDetailview(4);
                            break;
                        case "Chives":
                            navigateToDetailview(5);
                            break;
                        case "Cabbage":
                            navigateToDetailview(6);
                            break;
                        case "Bell Pepper":
                            navigateToDetailview(7);
                            break;
                        case "Bean":
                            navigateToDetailview(8);
                            break;
                        case "Pumpkin":
                            navigateToDetailview(9);
                            break;
                        default:
                            break;
                    }             
            });
        }

        private void navigateToDetailview(int growableItemNumber)
        {
            Messenger.Default.Send<GrowableItem>(GrowableItemListToSend[growableItemNumber]);
            navigationService.NavigateTo("Detail");
        }

        private void loadData()
        {
            GrowableItemListToSend.Clear();

            GrowableItemListRevceived = growableDataservice.GetAllGrowableItems();

            string imagePath;
            int index;

            foreach (var growableItem in GrowableItemListRevceived)
            {
                imagePath = growableItem.Image.ToLower();
                index = imagePath.LastIndexOf('/');
                growableItem.Image = imagePath.Substring(index);
                GrowableItemListToSend.Add(growableItem);
            }
        }
    }
 }
