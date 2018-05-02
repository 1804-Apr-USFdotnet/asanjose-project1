using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataLayer;


namespace ClassProj
{
    public class PartialSearch
    {

        public void  SearchFunc<T>(List<T> rlist ){

            Console.WriteLine("Please type what you want to search");
            string desired = Console.ReadLine();

            using (var db = new RestDbContent())
            {

                var query = from part in db.restaurants
                            where part.Cuisine.Contains(desired) ||
                            part.Restaurant.Contains(desired) ||
                            part.City.Contains(desired)
                            select part;

                foreach (var item in query)
                {
                    Console.WriteLine(item);

                }


            }



        }


    }
}
