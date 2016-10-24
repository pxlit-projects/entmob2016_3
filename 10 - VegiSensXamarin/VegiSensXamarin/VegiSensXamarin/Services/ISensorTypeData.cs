﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensDomain;

namespace VegiSensXamarin.Services
{
    public interface ISensorTypeData
    {
        ObservableCollection<SensorType> GetAllSensorTypes();
    }
}