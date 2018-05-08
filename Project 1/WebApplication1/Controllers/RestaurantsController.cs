using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using DataLayer.Models;


namespace WebApplication1.Controllers
{
    public class RestaurantsController : Controller
    {
        RestaurantsClass crud = new RestaurantsClass();
        ReviewClass reviewcrud = new ReviewClass();
        RestaurantModel model = new RestaurantModel();
        



        // GET: RestaurantsClasses
        public ActionResult Index(string searchstring)
        {

            var rests = crud.GetRestaurantModel();

            if (!String.IsNullOrEmpty(searchstring))
            {
                rests = crud.GetRest(searchstring);
            }

            return View(rests);
        }

        public ActionResult SortDescend()
        {
            var rests = crud.SortDescend();
            return View(rests);

        }

        public ActionResult SortAscend()
        {
            var rests = crud.SortAscend();
            return View(rests);

        }

        public ActionResult Topthree()
        {

            var rests = crud.SortRating();
            return View(rests);
        }


    // GET: RestaurantsClasses/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantsClass restaurantsClass = crud.getID(id);
            if (restaurantsClass == null)
            {
                return HttpNotFound();
            }
            return View(restaurantsClass);
        }

        // GET: RestaurantsClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantsClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestID,Restaurant,Address,City,Rating,Cuisine,Created,Modified")] RestaurantsClass restaurantsClass)
        {
            if (ModelState.IsValid)
            {
                crud.Add(restaurantsClass);
                
                return RedirectToAction("Index");
            }

            return View(restaurantsClass);
        }

        // GET: RestaurantsClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantsClass restaurantsClass = crud.getID(id);
            if (restaurantsClass == null)
            {
                return HttpNotFound();
            }
            return View(restaurantsClass);
        }

        // POST: RestaurantsClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestID,Restaurant,Address,City,Rating,Cuisine,Created,Modified")] RestaurantsClass restaurantsClass)
        {
            if (ModelState.IsValid)
            {
                crud.Update(restaurantsClass);
                return RedirectToAction("Index");
            }
            return View(restaurantsClass);
        }

        // GET: RestaurantsClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantsClass restaurantsClass = crud.getID(id);
            if (restaurantsClass == null)
            {
                return HttpNotFound();
            }
            return View(restaurantsClass);
        }

        // POST: RestaurantsClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantsClass restaurantsClass = crud.getID(id);
            crud.Delete(restaurantsClass);
            return RedirectToAction("Index");
        }

       

        
    }
}
