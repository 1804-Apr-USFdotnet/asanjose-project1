using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   
        [Table("Review")]
        public class ReviewModel
        {
            
            public int RestID { get; set; }
            [ForeignKey("RestID")]
            public virtual Restaurants Restaurants { get; set; }
            
            public string Restaurant { get; set; }
            public decimal Rating { get; set; }
            public string Review { get; set; }
            [Key]
            public string UserID { get; set; }



            public ReviewModel()
            {



            }

            public ReviewModel(int ID, string name, decimal rating, string review, string user)
            {

                RestID = ID;
                Restaurant = name;
                Rating = rating;
                Review = review;
                UserID = user;


            }

            public override string ToString()
            {
                return $"\nRestID:{RestID} \nRestaurant: {Restaurant} \nRating: {Rating} \nReview: {Review} \nUserID: {UserID} ";

            }



        }
    }

