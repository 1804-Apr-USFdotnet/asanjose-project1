using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using DataLayer;


namespace DataLayer.Models
{


    [Table("Restaurant")]
    public class RestaurantModel : BaseEntity
    {
        public RestaurantModel()
        {
            this.ReviewModel = new HashSet<ReviewModel>();
        }


        [Key]
       
        public int RestID { get; set; }

        [Column("Restaurant")]
        [StringLength(50)][Required]
        public string Restaurant { get; set; }

        [StringLength(50)][Required]
        public string Address { get; set; }

        [StringLength(20)][Required]
        public string City { get; set; }

        [Range(0.00,5.00, ErrorMessage = "Please enter a value in between 0.00 and 5.00")]
        public decimal? Rating { get; set; }

        [StringLength(20)] [Required]
        public string Cuisine { get; set; }

       
 
        public virtual ICollection<ReviewModel> ReviewModel { get; set; }


       public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


        

    }
}
