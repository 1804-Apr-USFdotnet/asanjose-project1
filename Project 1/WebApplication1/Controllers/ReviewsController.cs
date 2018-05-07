using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using DataLayer;

namespace WebApplication1.Controllers
{
    public class ReviewsController : Controller
    {
        ReviewClass crud = new ReviewClass();
        RestaurantsClass restcrud = new RestaurantsClass();

        // GET: ReviewClasses
        public ActionResult Index()
        {
            var reviewModels = crud.getReviews();
            return View(reviewModels);
        }

        // GET: ReviewClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewClass reviewClass = crud.getID(id);
            if (reviewClass == null)
            {
                return HttpNotFound();
            }
            return View(reviewClass);
        }

        // GET: ReviewClasses/Create
        public ActionResult Create(int id, string name)
        {
            var rev = new ReviewClass();
            rev.RestID = id;
            return View(rev);
        }

        // POST: ReviewClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RevID,RestID,Restaurant,Rating,Review,UserID")] ReviewClass reviewClass, int id)
        {
            if (ModelState.IsValid)
            {
                reviewClass = crud.getID(id);
                crud.Add(reviewClass);
                return RedirectToAction("Index");
            }

            ViewBag.RestID = new SelectList(restcrud.GetRestaurantModel(), "RestID", "Restaurant", reviewClass.RestID);
            return View(reviewClass);
        }

        // GET: ReviewClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewClass reviewClass = crud.getID(id);
            if (reviewClass == null)
            {
                return HttpNotFound();
            }
           ViewBag.RestID = new SelectList(restcrud.GetRestaurantModel(), "RestID", "Restaurant", reviewClass.RestID);
            return View(reviewClass);
        }

        // POST: ReviewClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RevID,RestID,Restaurant,Rating,Review,UserID")] ReviewClass reviewClass)
        {
            if (ModelState.IsValid)
            {
                crud.Update(reviewClass);              
                return RedirectToAction("Index");
            }
           // ViewBag.RestID = new SelectList(restcrud.GetRestaurantModel(), "RestID", "Restaurant", reviewClass.RestID);
            return View(reviewClass);
        }

        // GET: ReviewClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewClass reviewClass = crud.getID(id);
            if (reviewClass == null)
            {
                return HttpNotFound();
            }
            return View(reviewClass);
        }

        // POST: ReviewClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewClass reviewClass = crud.getID(id);
            crud.Delete(reviewClass);
            
            return RedirectToAction("Index");
        }

  
    }
}
