using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData RestaurantsData;

        public RestaurantCountViewComponent(IRestaurantData RestaurantsData)
        {
            this.RestaurantsData = RestaurantsData;
        }

        public IViewComponentResult Invoke()
        {
            var count = RestaurantsData.GetCountOfRestaurants();
            return View("", count);
        }
    }
}
