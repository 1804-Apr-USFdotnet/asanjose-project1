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
        List<RestaurantsClass> res = new List<RestaurantsClass>();



        public IEnumerable<RestaurantModel> GetRestaurantModel()
        {
            var result = crud.GetRestaurants();
            var rest = result.Select(x => ToWeb(x));
            return rest;

        }


        public IEnumerable<RestaurantModel> GetRest(string desired)
        {
            var result = crud.GetRestaurant(desired);
            var rest = result.Select(x => ToWeb(x));
            return rest;

        }


        public IEnumerable<RestaurantModel> SortRating()
        {
            var result = crud.SortRating();
            result = result.Select(x => ToWeb(x));
            return result;
        }

        public IEnumerable<RestaurantModel> SortDescend()
        {
            var result = crud.SortDescend();
            result = result.Select(x => ToWeb(x));
            return result;
        }

        public IEnumerable<RestaurantModel> SortAscend()
        {
            var result = crud.SortAscend();
            result = result.Select(x => ToWeb(x));
            return result;
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
                ReviewModel = new List<ReviewModel>()

            };
            foreach (var review in dataRestaurant.ReviewModel)
            {
                var temp = new ReviewModel
                {
                    RevID = review.RevID,
                    RestID = review.RestID,
                    UserID = review.UserID,
                    Review = review.Review,
                    Rating = review.Rating,
                    Restaurant = review.Restaurant
                };

                webRest.ReviewModel.Add(temp);
            }

            return webRest;
        }




        public float GetAverage()
        {
            float sum = 0F;
            foreach (var review in ReviewModel)
            {
                sum += (float)review.Rating;

            }

            return (sum / ReviewModel.Count);

        }



    }
}

    


