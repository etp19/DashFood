using DashFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace DashFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id); 
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1, Name="Scott's Pizza", Location="Maryland", Cousine=CuisineType.Italian},
                new Restaurant { Id=2, Name="De Lucas", Location="Lansing", Cousine=CuisineType.Italian},
                new Restaurant { Id=3, Name="Texas RoadHouse", Location="Novi", Cousine=CuisineType.American},
                new Restaurant { Id=4, Name="India Place", Location="Detroit", Cousine=CuisineType.Indian},
                new Restaurant { Id=5, Name="Cancun", Location="Lansing", Cousine=CuisineType.Mexican},
                new Restaurant { Id=6, Name="Five Guys", Location="Royal Oak", Cousine=CuisineType.American},
            };
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
