using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DataLayer
{


    [Table("Restaurant")]
    public class Restaurants
    {
        [Key]
       
        public int RestID { get; set; }

        [Column("Restaurant")]
        [StringLength(50)]
        public string Restaurant { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public decimal? Rating { get; set; }

        [StringLength(50)]
        public string Cuisine { get; set; }

        public ICollection<ReviewModel> reviewModels { get; set; }


        public Restaurants()
        {
        }

        public Restaurants(int restid, string rest, string address, string city, decimal rate, string cuisine)
        {
            RestID = restid;
            Restaurant = rest;
            Address = address;
            City = city;
            Rating = rate;
            Cuisine = cuisine;

        }

        public override string ToString()
        {
            return $"\nRestID:{RestID} \nRname: {Restaurant} \nAddress: {Address} \nCity: {City} \nRating: {Rating} \nCuisine: {Cuisine} ";

        }
    }
}
