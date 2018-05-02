using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ClassProj
{
    public partial class Display
    {

        public List<T> DisplayRestaurants<T>(List<T> rest)
        {

            using (var db = new RestDbContent())
            {
                var query = from r in db.restaurants
                            select r;
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

                return rest;

            }
        }


        public void RestNames<T>(List<T> rest)
        {
            using (var db = new RestDbContent())
            {
                var query = from r in db.restaurants
                            select r.Restaurant;


                foreach (var item in query)
                {
                    Console.WriteLine(item);

                }

            }

            

        }
    }
}