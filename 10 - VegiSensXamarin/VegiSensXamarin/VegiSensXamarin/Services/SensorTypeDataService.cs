using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSensDomain;

namespace VegiSensXamarin.Services
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
        public ObservableCollection<SensorType> GetAllSensorTypes()
        {
            return repository.GetAllSensorTypes();
        }

        ObservableCollection<SensorType> ISensorTypeData.GetAllSensorTypes()
        {
            throw new NotImplementedException();
        }
    }
}
