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
    public class MockSensorTypeRepository : ISensorTypeRepository
    {
        //Properties
        private static ObservableCollection<SensorType> sensorTypes;

        //Constructor
        public MockSensorTypeRepository()
        {
        }

        public ObservableCollection<SensorType> GetAllSensorTypes()
        {
            if (sensorTypes == null)
            {
                loadSensorTypeItems();
            }

            return sensorTypes;
        }

        //Load all Growable Items
        private void loadSensorTypeItems()
        {
            //Create a new httpclient instance
            using (var client = new HttpClient())
            {
                //Set URL
                client.BaseAddress = new Uri("http://localhost:8081/sensortypes");

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
                    sensorTypes = JsonConvert.DeserializeObject<ObservableCollection<SensorType>>(result);
                }
            }
        }
    }
}
