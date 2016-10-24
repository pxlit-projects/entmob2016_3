using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;

namespace VegiSens.Test.Mocks
{
    public class MockVegetableRepository : IVegetableRepository
    {
        //Properties
        private static ObservableCollection<GrowableItem> growableItems;

        //Constructor
        public MockVegetableRepository()
        {
        }

        public void AddVegetableItem(GrowableItem growableItemToAdd)
        {
            throw new NotImplementedException();
        }


        public ObservableCollection<GrowableItem> GetAllGrowableItems()
        {
            if (growableItems == null)
            {
                loadGrowableItems();
            }

            return growableItems;
        }

        //Methods
        public GrowableItem GetGrowableItemById(int growableItemID)
        {
            if (growableItems == null)
            {
                loadGrowableItems();
            }

            return growableItems.Where(g => g.GrowableItemID == growableItemID).FirstOrDefault();
        }

        //Load all Growable Items
        private void loadGrowableItems()
        {
            //Create a new httpclient instance
            using (var client = new HttpClient())
            {
                //Set URL
                client.BaseAddress = new Uri("http://localhost:8081/growableItems");

                //Clear evrything before starting
                client.DefaultRequestHeaders.Accept.Clear();

                //Set the format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get the connection with the URL and return the result (succes or not)
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

                //If the resposne succeeded
                if (response.IsSuccessStatusCode)
                {
                    //Read the data as a json
                    var result = response.Content.ReadAsStringAsync().Result;

                    //Convert the json result to the specified type
                    growableItems = JsonConvert.DeserializeObject<ObservableCollection<GrowableItem>>(result);
                }
            }
        }
    }
}

