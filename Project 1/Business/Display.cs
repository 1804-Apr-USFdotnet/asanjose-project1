using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using DataLayer;


namespace ClassProj
    {
    public partial class Display
        {
            public void DisplayReviews<T>(List<T> review) //Could be used similarilly for displaying details as well
            {
                Console.WriteLine("Which reviews would you like to see: ");
                  var desired = Console.ReadLine();
                using (var db = new RestDbContent())
                {
                var query = from r in db.reviews
                            where r.Restaurant.Contains(desired)
                                select r;
                    foreach (var item in query)
                    {
                    Console.WriteLine(item);
                    }

                }
            }

        
            public void DisplayTop3<T>(List<T> datainfo)
            {

            using (var db = new RestDbContent())
            {
                var query = (from r in db.restaurants
                             orderby r.Rating descending
                             select r).Take(3);

                Console.WriteLine("These are the top 3 Restaurants:");
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

            }

        }


            public decimal DisplayAvg<T>(List<T> rating)
            {

            Console.WriteLine("Which restaurant would you like to see averaged?");
            var desired = Console.ReadLine();

            using (var db = new RestDbContent())
            {
                var result = (from r in db.reviews
                              where r.Restaurant.Equals(desired)
                              select r.Rating).Average();

                Console.WriteLine(result);

                return result;

            }

            }



    }
}
