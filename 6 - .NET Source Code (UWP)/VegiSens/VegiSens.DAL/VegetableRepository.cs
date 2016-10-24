using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;

namespace VegiSens.DAL
{
    public class VegetableRepository : IVegetableRepository
    {
        //Properties
        private static ObservableCollection<GrowableItem> growableItems;

        //Constructor
        public VegetableRepository()
        {

        }

        //Methods
        public async void AddVegetableItem(GrowableItem growableItemToAdd)
        {         
            //Create a new httpclient instances
            using (var client = new HttpClient())
            {
                //Set URL
                client.BaseAddress = new Uri("http://localhost:8081/growableItems/add");

                //Clear evrything before starting
                client.DefaultRequestHeaders.Accept.Clear();

                //Set the format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Add base64 string to header
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("arno:pxl")));

                var growableItem = JsonConvert.SerializeObject(growableItemToAdd);

                //Make properties lowercase
                growableItem = growableItem.Replace("Name", "name");
                growableItem = growableItem.Replace("Description", "description");
                growableItem = growableItem.Replace("Image", "image");

                growableItem = growableItem.Replace("Temperature", "temperature");
                growableItem = growableItem.Replace("Maxtemperature", "maxTemperature");
                growableItem = growableItem.Replace("Mintemperature", "minTemperature");

                growableItem = growableItem.Replace("Humidity", "humidity");
                growableItem = growableItem.Replace("Maxhumidity", "maxHumidity");
                growableItem = growableItem.Replace("Minhumidity", "minHumidity");

                //Get the connection with the URL and return the result (succes or not)
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, new StringContent(growableItem.ToString(), Encoding.UTF8, "application/json"));

                loadGrowableItems();
            }
        }

        public ObservableCollection<GrowableItem> GetAllGrowableItems()
        {
            if (growableItems == null)
            {
                loadGrowableItems();
            }

            return growableItems;
        }

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

                //Add base64 string to header
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("arno:pxl")));

                //Get the connection with the URL and return the result (succes or not)
                HttpResponseMessage response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;

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
