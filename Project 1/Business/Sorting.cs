using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace ClassProj
{
    public class Sorting
    {
        public int i = 0;
        public List<T> SortAscend<T>(List<T> content)
        {

            using (var db = new RestDbContent())
            {
                var data = (from name in db.restaurants
                            orderby name.Restaurant ascending
                            select name);

                foreach (var item in data)
                {
                    Console.WriteLine(item);


                }

                return content;
            }
        }


        public void SortDescend<T>(List<T> content)
        {
            List<string> content1 = new List<string>();

            using (var db = new RestDbContent())
            {
                var data = (from name in db.restaurants
                            orderby name.Restaurant descending
                            select name);

                foreach (var item in data)
                {
                    Console.WriteLine(item);
                   
                }

            }
   
        }




        public void SortCuisine<T>(List<T> type)
        {
           

            using (var db = new RestDbContent())
            {
                var data = (from name in db.restaurants
                            orderby name.Cuisine ascending
                            select name);

                foreach (var item in data)
                {
                    Console.WriteLine(item);


                }

            }


        }
    }
}
