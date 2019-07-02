using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;

        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration _configuration, IRestaurantData _restaurantData)
        {
            configuration = _configuration;
            restaurantData = _restaurantData;
        }

        public void OnGet()
        {
            Message = configuration["Message"];
            Restaurants = restaurantData.GetAll();
        }
    }
}