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

namespace VegiSensXamarin.ViewModel
{
    public class GroentenMenuViewModel : ViewModelBase
    {
        private IGrowableItemDataService growableDataservice;
        private INavigationService navigationService;

        private ObservableCollection<GrowableItem> GrowableItemListRevceived { get; set; }
        private ObservableCollection<GrowableItem> GrowableItemListToSend { get; set; }
        public GrowableItem GrowableItem { get; set; }

        public ICommand ViewDetailCommand { get; set; }


        public GroentenMenuViewModel(INavigationService navigationService, IGrowableItemDataService growableDataservice)
        {
            this.growableDataservice = growableDataservice;
            this.navigationService = navigationService;

            InitializeCommands();
            loadData();
        }

        private void InitializeCommands()
        {
            ViewDetailCommand = new Command(() =>
            {
                navigationService.NavigateTo("Detail");
            });
        }

        private void loadData()
        {
            //GrowableItemListToSend.Clear();

            //GrowableItemListRevceived = growableDataservice.GetAllGrowableItems();

            //string imagePath;
            //int index;

            //foreach (var growableItem in GrowableItemListRevceived)
            //{
            //    imagePath = GrowableItem.Image.ToLower();
            //    index = imagePath.LastIndexOf('/');
            //    growableItem.Image = imagePath.Substring(index);
            //    GrowableItemListToSend.Add(growableItem);
            //}

            GrowableItemListRevceived = growableDataservice.GetAllGrowableItems();


            GrowableItem = GrowableItemListRevceived[0];
            string imagePath = GrowableItem.Image.ToLower();
            int index = imagePath.LastIndexOf('/');

            GrowableItem.Image = imagePath.Substring(index);
            GrowableItemListRevceived[0] = GrowableItem;
        }
    }
 }
