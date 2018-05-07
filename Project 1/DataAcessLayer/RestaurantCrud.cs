using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer;

namespace DataAcessLayer
{
    public class RestaurantCrud
    {
        RestDbContent db = new RestDbContent();

        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            return db.restaurants.ToList();

        }

        public RestaurantModel GetById(int? id)
        {

            return db.restaurants.Find(id);

        }

         public void AddRestaurant(RestaurantModel restaurant)
        {
            db.restaurants.Add(restaurant);
            db.SaveChanges();

        }

        public void RemoveRestaurant(RestaurantModel restaurant)
        {
            var _db = db.restaurants.Where(u => u.RestID.Equals(restaurant.RestID)).FirstOrDefault();
            db.restaurants.Remove(_db);
            db.SaveChanges();

        }
           
        public void UpdateRestaurant(RestaurantModel restaurant)
        {
            var rest = db.restaurants.Find(restaurant.RestID);
            if(rest!= null)
            {
                db.Entry(rest).CurrentValues.SetValues(restaurant);
                db.SaveChanges();
            }

        }
        



    }
}
