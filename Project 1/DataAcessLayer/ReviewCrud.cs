using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace DataAcessLayer
{
    public class ReviewCrud
    {
        RestDbContent db = new RestDbContent();

        public IEnumerable<ReviewModel> GetReviews()
        {
            return db.reviews.ToList();

        }

        public ReviewModel GetReviewById(int? id)
        {
            return db.reviews.Find(id);

        }

        public void AddReview(ReviewModel review)
        {
            db.reviews.Add(review);
            db.SaveChanges();

        }

        public void DeleteReview(ReviewModel review)
        {
            var _db = db.reviews.Where(u => u.RevID.Equals(review.RevID)).FirstOrDefault();
            db.reviews.Remove(_db);
            db.SaveChanges();
        }

        public void EditReview(ReviewModel review)
        {
            var rev = db.reviews.Find(review.RestID);
            if (rev != null)
            {
                db.Entry(rev).CurrentValues.SetValues(review);
                db.SaveChanges();
            }

        }
    }
}
