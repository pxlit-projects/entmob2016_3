using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;
using VegiSens.DAL;
using System.Collections.ObjectModel;
using VegiSens.Services;

namespace VegiSens.Test.Mocks
{
    public class MockSensorTypeDataService : ISensorTypeData
    {
        //Properties
        ISensorTypeRepository repository = new MockSensorTypeRepository();

        //Constructor
        public MockSensorTypeDataService()
        {

        }

        //Methods
        public ObservableCollection<SuperSensor> GetAllSensorTypes()
        {
            return repository.GetAllSensorTypes();
        }
    }
}
