﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;

namespace VegiSens.Services
{
    public class GrowableITemDataService : IGrowableItemData
    {
        //Properties
        IVegetableRepository repository;

        //Constructor
        public GrowableITemDataService(IVegetableRepository repository)
        {
            this.repository = repository;
        }

        //Methods
        public GrowableItem GetGrowableItemById(int growableItemID)
        {
            return repository.GetGrowableItemById(growableItemID);
        }

        public ObservableCollection<GrowableItem> GetAllGrowableItems()
        {
            return repository.GetAllGrowableItems();
        }

        //public void UpdateCoffee(Coffee coffee)
        //{
        //    repository.UpdateCoffee(coffee);
        //}

        //public void DeleteCoffee(Coffee coffee)
        //{
        //    repository.DeleteCoffee(coffee);
        //}
    }
}
