using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlyBuy.Models;
using System.IO;

namespace FlyBuy.Controllers
{
    
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,LastUpdated,AgeCategory,Image,ImageFile,Rating,CategoryId")] Product product)
        {
            
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extenstion = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extenstion;
            product.Image = "~/Content/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            product.ImageFile.SaveAs(fileName);


            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,LastUpdated,AgeCategory,Image,ImageFile,Rating,CategoryId")] Product product)
        {

            string fileName;
            string extenstion;

            if (product.ImageFile == null || product.ImageFile == null)
            {
                return RedirectToAction("Index");
            }

            fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            extenstion = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extenstion;
            product.Image = "~/Content/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            product.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //[Route("Products/Fshi/{id}")]
        //public JsonResult Fshi(int? id)
        //{
        //    Product Produkti =  new Product();
        //    db.Products.Remove(Produkti);
        //    int result = db.SaveChanges();
        //    return Json(result,JsonRequestBehavior.AllowGet);
        //}

        [Authorize(Roles = "Admin , Users")]
        public ActionResult ShoppingCard()
        {
            ViewBag.ListProducts = db.Products.ToList();
            return View();
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult AllProducts()
        {
            var allproducts  = db.Products.ToList();
            return View(allproducts.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public  ActionResult SortByPrice()
        {
            var sortbyprice  =  db.Products.OrderByDescending(x => x.Price).ToList();
            
            return View(sortbyprice.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult SortByRate()
        {
            var sortbyprice = db.Products.OrderByDescending(x => x.Rating).ToList();
            return View(sortbyprice.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult SortByCategory(string category)
        {

            ViewData["Categories"] = db.Categories.ToList();
            var sortbyCategory = db.Products.Where(p => p.Category.Name == category).ToList();
            
            return View(sortbyCategory.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult Man()
        {
            var sortByAgeCategory = db.Products.Where(p => p.AgeCategory == "Male").ToList();
            return View(sortByAgeCategory.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult Woman()
        {
            var sortByAgeCategory = db.Products.Where(p => p.AgeCategory == "Female").ToList();
            return View(sortByAgeCategory.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult Kid()
        {
            var sortByAgeCategory = db.Products.Where(p => p.AgeCategory == "Kids").ToList();
            return View(sortByAgeCategory.ToList());
        }

        [Authorize(Roles = "Admin , Users")]
        public ActionResult Old()
        {
            var sortByAgeCategory = db.Products.Where(p => p.AgeCategory == "Old").ToList();
            return View(sortByAgeCategory.ToList());
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
