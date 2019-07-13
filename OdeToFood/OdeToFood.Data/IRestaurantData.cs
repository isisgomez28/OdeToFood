using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
        Restaurant Delete(int id);
        Restaurant GetRestaurantById(int id);
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant Update(Restaurant updatedRestaurant);
        int GetCountOfRestaurants();
    }
}