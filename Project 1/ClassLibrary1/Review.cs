using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataAcessLayer;

namespace ClassLibrary1
{
    public class ReviewClass : ReviewModel
    {
        ReviewCrud crud = new ReviewCrud();


        public IEnumerable<ReviewModel> getReviews()
        {
            var result = crud.GetReviews();
            var rev = result.Select(x => ToWeb(x));
            return rev;

        }


        public ReviewClass getID(int? id)
        {
            return ToWeb(crud.GetReviewById(id));

        }


        public void Add(ReviewClass reviewclass)
        {
            crud.AddReview(ToData(reviewclass));


        }

        public void Delete(ReviewClass reviewclass)
        {
            crud.DeleteReview(ToData(reviewclass));
        }

        public void Update(ReviewClass reviewclass)
        {

            crud.EditReview(ToData(reviewclass));

        }

        public static DataLayer.Models.ReviewModel ToData(ReviewClass classreview)
        {
            var DataReview = new DataLayer.Models.ReviewModel()
            {
                RevID = classreview.RevID,
                RestID = classreview.RestID,
                UserID = classreview.UserID,
                Restaurant = classreview.Restaurant,
                Review = classreview.Review,
                Rating = classreview.Rating,
               
                
            };

            return DataReview;
        }



        public static ReviewClass ToWeb(DataLayer.Models.ReviewModel datareview)
        {

            var WebReview = new ReviewClass()
            {
                RevID = datareview.RevID,
                RestID = datareview.RestID,
                UserID = datareview.UserID,
                Restaurant = datareview.Restaurant,
                Review = datareview.Review,
                Rating = datareview.Rating,

            };

            return WebReview;

        }
    }
}
