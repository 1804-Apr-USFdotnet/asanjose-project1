using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer.Models
{
   
        [Table("Review")]
        public class ReviewModel: BaseEntity
        {
            [Key]
            public int RevID { get; set; }    
            
        
            public int RestID { get; set; }
           
         
            public virtual RestaurantModel Restaurants { get; set; }
            
            public string Restaurant { get; set; }
            [Required][Range(0.00, 5.00, ErrorMessage = "Please enter a value in between 0.00 and 5.00")]
            public decimal Rating { get; set; }
            public string Review { get; set; }
            [Required][StringLength(50)]
            public string UserID { get; set; }

            [NotMapped]
            DateTime Created { get; set; }
            [NotMapped]
            DateTime? Modified { get; set; }

    }
    }

