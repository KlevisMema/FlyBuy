using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlyBuy.Models;

namespace FlyBuy.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AgeCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AgeCategories
        public ActionResult Index()
        {
            return View(db.AgeCategories.ToList());
        }

        // GET: AgeCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeCategorie ageCategorie = db.AgeCategories.Find(id);
            if (ageCategorie == null)
            {
                return HttpNotFound();
            }
            return View(ageCategorie);
        }

        // GET: AgeCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgeCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,File,Name")] AgeCategorie ageCategorie)
        {

            if (ageCategorie.File == null)
            {
                return RedirectToAction("Index");
            }

            string fileName = Path.GetFileNameWithoutExtension(ageCategorie.File.FileName);
            string extenstion = Path.GetExtension(ageCategorie.File.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extenstion;
            ageCategorie.Image = "~/Content/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            ageCategorie.File.SaveAs(fileName);


            if (ModelState.IsValid)
            {
                db.AgeCategories.Add(ageCategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ageCategorie);
        }

        // GET: AgeCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeCategorie ageCategorie = db.AgeCategories.Find(id);
            if (ageCategorie == null)
            {
                return HttpNotFound();
            }
            return View(ageCategorie);
        }

        // POST: AgeCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,File,Name")] AgeCategorie ageCategorie)
        {
            if(ageCategorie.File == null)
            {
                return RedirectToAction("Index");
            }
            string fileName = Path.GetFileNameWithoutExtension(ageCategorie.File.FileName);
            string extenstion = Path.GetExtension(ageCategorie.File.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extenstion;
            ageCategorie.Image = "~/Content/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            ageCategorie.File.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Entry(ageCategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ageCategorie);
        }

        // GET: AgeCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeCategorie ageCategorie = db.AgeCategories.Find(id);
            if (ageCategorie == null)
            {
                return HttpNotFound();
            }
            return View(ageCategorie);
        }

        // POST: AgeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgeCategorie ageCategorie = db.AgeCategories.Find(id);
            db.AgeCategories.Remove(ageCategorie);
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