using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Salon.Models;

namespace Salon.Controllers
{
    public class Car_dealershipController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Car_dealership
        public ActionResult Index()
        {
            return View(db.Car_dealership.ToList());
        }

        // GET: Car_dealership/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_dealership car_dealership = db.Car_dealership.Find(id);
            if (car_dealership == null)
            {
                return HttpNotFound();
            }
            return View(car_dealership);
        }

        public ActionResult Cars(int id)
        {
            var model = new Price();
            var car_d = db.Car_dealership.Find(id);
            model.Car_dealershipId = id;
            model.Car_Dealership = car_d;
            var cars = car_d.Cars.ToList();
            model.Cars = cars;
            var list = db.Prices.Where(item => item.Car_dealershipId.Equals(id)).ToList();
            var dic = new Dictionary <int, string >();
            foreach (var item in list)
            {
                dic.Add(item.CarId, item.price);
            }
            ViewData["d"] = dic;
            return View(model);
        }
        public ActionResult Add_price(int id, int car_d)
        {
            var model = new Price();
            model.CarId = id;
            model.Car_dealershipId = car_d;
            return View(model);
        }
        [HttpPost]
        public ActionResult Add_price(Price model)
        {
            var list = db.Prices.Where(item => item.Car_dealershipId.Equals(model.Car_dealershipId)).ToList();
            foreach (var item in list)
            {
                if (item.CarId.Equals(model.CarId))
                {
                    item.price = model.price;
                    db.SaveChanges();
                    return RedirectToAction("Cars", new { id = model.Car_dealershipId });
                }
            }
            db.Prices.Add(model);
            db.SaveChanges();
            return RedirectToAction("Cars", new { id = model.Car_dealershipId });
        }

        // GET: Car_dealership/Create
        public ActionResult Add_Car(int id)
        {
            var model = new Add_Car();
            model.Car_dealershipId = id;
            model.Cars = db.Cars.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add_Car(Add_Car model)
        {
            var car_d = db.Car_dealership.Find(model.Car_dealershipId);
            var car = db.Cars.Find(model.CarId);
            car_d.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete_Car(int id)
        {
            var cd = db.Car_dealership.Find(id);
            var model = new Add_Car();
            model.Car_dealershipId = id;
            model.Cars = cd.Cars.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete_Car(Add_Car model)
        {
            var car_d = db.Car_dealership.Find(model.Car_dealershipId);
            var car = db.Cars.Find(model.CarId);
            car_d.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Favorite()
        {
            return View(db.Favorites.ToList());
        }
        public ActionResult Del_Favorite(int id)
        {
            var m = db.Favorites.Find(id);
            db.Favorites.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Favorite");
        }
        [HttpPost]
        public ActionResult Add_Favorite(int id, int car_d)
        {
            var prid = db.Prices.Where(item => item.Car_dealershipId.Equals(car_d)).ToList();
            foreach (var item in prid)
            {
                if (item.CarId.Equals(id))
                {
                    var imali = db.Favorites.Where(ima => ima.PriceId.Equals(item.PriceId)).ToList();
                    if(imali.Count != 0)
                    {
                        return RedirectToAction("Favorite");
                    }
                    var car = db.Cars.Find(id);
                    var model = new Favorite();
                    model.Image = car.Image;
                    model.PriceId = item.PriceId;
                    db.Favorites.Add(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Favorite");
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Car_dealership/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Car_dealershipId,Name,City")] Car_dealership car_dealership)
        {
            if (ModelState.IsValid)
            {
                db.Car_dealership.Add(car_dealership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car_dealership);
        }

        // GET: Car_dealership/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_dealership car_dealership = db.Car_dealership.Find(id);
            if (car_dealership == null)
            {
                return HttpNotFound();
            }
            return View(car_dealership);
        }

        // POST: Car_dealership/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Car_dealershipId,Name,City")] Car_dealership car_dealership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_dealership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car_dealership);
        }

        public ActionResult Delete(int id)
        {
            Car_dealership del = db.Car_dealership.Find(id);
            db.Car_dealership.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
