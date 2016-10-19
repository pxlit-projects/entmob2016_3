using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;
using VegiSens.DAL;

namespace VegiSens.Services
{
    public class SensorTypeDataService : ISensorTypeData
    {
        //Properties
        ISensorTypeRepository repository;

        //Constructor
        public SensorTypeDataService(ISensorTypeRepository repository)
        {
            this.repository = repository;
        }

        //Methods
        public ObservableCollection<SuperSensor> GetAllSensorTypes()
        {
            return repository.GetAllSensorTypes();
        }  
    }
}
