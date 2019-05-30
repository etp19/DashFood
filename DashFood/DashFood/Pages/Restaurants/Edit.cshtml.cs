using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashFood.Core;
using DashFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DashFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        public Restaurant Restaurant;
        private readonly IRestaurantData restaurantData;
        public EditModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}