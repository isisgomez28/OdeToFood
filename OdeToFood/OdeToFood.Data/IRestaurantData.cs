﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pastisal", Cuisine = CuisineType.Italian, Location = "Santo Domingo" },
                new Restaurant { Id = 2, Name = "Bachata Rosa", Cuisine = CuisineType.None, Location = "Punta Cana"},
                new Restaurant { Id = 3, Name = "Scott's Pizza", Cuisine = CuisineType.Italian, Location =  "Maryland"},
                new Restaurant { Id = 4, Name = "Cinnamon Club", Cuisine = CuisineType.Indian, Location = "New York"},
                new Restaurant { Id = 5, Name = "La Costa", Cuisine = CuisineType.Mexican, Location = "Boston"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}