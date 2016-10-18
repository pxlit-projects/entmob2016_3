﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiEF.Model
{
    public class Temperature
    {
        public Temperature()
        {
            GrowableItems = new List<GrowableItem>();
        }

        [Key]
        private int temperatureID;

        private double maxTemperature;
        private double minTemperature;

        public virtual ICollection<GrowableItem> GrowableItems { get; set; }

        public int TemperatureID { get { return temperatureID; } set { temperatureID = value; } }
        public double MaxTemperature { get { return maxTemperature; } set { maxTemperature = value; } }
        public double MinTemperature { get { return minTemperature; } set { minTemperature = value; } }
    }
}