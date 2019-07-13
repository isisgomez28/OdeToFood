using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            this.context = dbContext;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            context.Add(newRestaurant);
            
            return newRestaurant;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);

            if (restaurant != null)
                context.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return context.Restaurants.Count();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in context.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = context.Restaurants.Attach(updatedRestaurant);

            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }
    }
}
