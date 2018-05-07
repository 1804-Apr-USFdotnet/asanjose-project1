using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer;
using DataAcessLayer;


namespace ClassLibrary1
{
    public class RestaurantsClass : RestaurantModel
    {

        RestaurantCrud crud = new RestaurantCrud();


        public IEnumerable<RestaurantModel> GetRestaurantModel()
        {
            var result = crud.GetRestaurants();
            var rest = result.Select(x => ToWeb(x));
            return rest;

        }


        public RestaurantsClass getID(int? id)
        {
            return ToWeb(crud.GetById(id));

        }


        public void Add(RestaurantsClass restaurantclass)
        {
           crud.AddRestaurant(ToData(restaurantclass));


        }

        public void Delete(RestaurantsClass restaurantclass)
        {
            crud.RemoveRestaurant(ToData(restaurantclass));
        }

        public void Update(RestaurantsClass restaurantclass)
        {

            crud.UpdateRestaurant(ToData(restaurantclass));

        }

        public static DataLayer.Models.RestaurantModel ToData(RestaurantsClass classrest)
        {
            var DataRestaurant = new DataLayer.Models.RestaurantModel()
            {
                RestID = classrest.RestID,
                Restaurant = classrest.Restaurant,
                Address = classrest.Address,
                City = classrest.City,
                Rating = classrest.Rating,
                Cuisine = classrest.Cuisine,
                Created = classrest.Created,
                Modified = classrest.Modified
                
            };
                
            return DataRestaurant;
        } 



            public static RestaurantsClass ToWeb(DataLayer.Models.RestaurantModel dataRestaurant)
        {

            var webRest = new RestaurantsClass()
            {
                RestID = dataRestaurant.RestID,
                Restaurant = dataRestaurant.Restaurant,
                Address = dataRestaurant.Address,
                City = dataRestaurant.City,
                Rating = dataRestaurant.Rating,
                Cuisine = dataRestaurant.Cuisine,

            };

            return webRest;

        }

        /*
        public override string ToString()
        {
            return $"\nRestID:{RestID} \nRname: {Restaurant} \nAddress: {Address} \nCity: {City} \nRating: {Rating} \nCuisine: {Cuisine} ";

        }
        */

    }
}

