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

        public ICollection<ReviewModel> ReviewModel { get; set; }


       public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


        public RestaurantModel()
        {
            ReviewModel = new HashSet<ReviewModel>();

        }

    }
}
