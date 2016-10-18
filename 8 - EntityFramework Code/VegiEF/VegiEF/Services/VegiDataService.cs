using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiEF.Model;

namespace VegiEF.Services
{
    class VegiDataService : IVegiDataService
    {
        public List<GrowableItem> GetAllGrowableItems()
        {
            throw new NotImplementedException();
            //string growableitems = "http://localhost:8080/api/growableitems";
            //var uri = new Uri(String.Format("{0}?format=json", growableitems));
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<GrowableItem>>(result);
            //return root.results;
        }

        public User GetAllGrowableItems(string uri)
        {
            throw new NotImplementedException();
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var GrowableItem = JsonConvert.DeserializeObject<GrowableItem>(result);
            //return growableitems;
        }

        public List<Humidity> GetAllHumidity()
        {
            throw new NotImplementedException();
            //string growableitems = "http://localhost:8080/api/humiditys";
            //var uri = new Uri(String.Format("{0}?format=json", humiditys));
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<Humidity>>(result);
            //return root.results;
        }

        public User GetAllHumidity(string uri)
        {
            throw new NotImplementedException();
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var Humidity = JsonConvert.DeserializeObject<Humidity>(result);
            //return humiditys;
        }

        public List<Light> GetAllLight()
        {
            throw new NotImplementedException();
            //string growableitems = "http://localhost:8080/api/lights";
            //var uri = new Uri(String.Format("{0}?format=json", lights));
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<Light>>(result);
            //return root.results;
        }

        public User GetAllLight(string uri)
        {
            throw new NotImplementedException();
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var Light = JsonConvert.DeserializeObject<Light>(result);
            //return lights;
        }

        public List<Temperature> GetAllTemperature()
        {
            throw new NotImplementedException();
            //string growableitems = "http://localhost:8080/api/temperatures";
            //var uri = new Uri(String.Format("{0}?format=json", temperatures));
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<Temperature>>(result);
            //return root.results;
        }

        public User GetAllTemperature(string uri)
        {
            throw new NotImplementedException();
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var Temperature = JsonConvert.DeserializeObject<Temperature>(result);
            //return temperatures;
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
            //string growableitems = "http://localhost:8080/api/users";
            //var uri = new Uri(String.Format("{0}?format=json", users));
            //var client = new HttpClient();
            //var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response.EnsureSuccessStatusCode();
            //var result = Task.Run(() =>
            //response.Content.ReadAsStringAsync()).Result;
            //var root = JsonConvert.DeserializeObject<RootObject<User>>(result);
            //return root.results;
        }

        public User GetSWMovieDetails(string uri)
        {
            throw new NotImplementedException();
        }

        class RootObject<T>
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<T> results { get; set; }
        }
    }
}
