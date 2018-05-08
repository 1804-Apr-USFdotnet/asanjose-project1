using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ClassLibrary1.Services
{
   public class BusinessLogic
    {
        RestaurantsClass test = new RestaurantsClass();
        public List<RestaurantModel> SortDescend()
        {
            var list = test.GetRestaurantModel();
            return list.OrderByDescending(x => x.RestID).ToList();
        }


        public List<RestaurantModel> SortAscend()
        {
            var list = test.GetRestaurantModel();
            return list.OrderBy(x => x.RestID).ToList();
        }


        public List<RestaurantModel> SortAscendName()
        {
            var list = test.GetRestaurantModel();
            return list.OrderBy(x => x.Restaurant).ToList();
        }

        public List<RestaurantModel> SortDescendName()
        {
            var list = test.GetRestaurantModel();
            return list.OrderByDescending(x => x.Restaurant).ToList();
        }

        public List<RestaurantModel> SortAscendCuisine()
        {
            var list = test.GetRestaurantModel();
            return list.OrderBy(x => x.Cuisine).ToList();
        }

       

    }
}
