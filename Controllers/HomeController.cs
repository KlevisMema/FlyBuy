using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyBuy.Models;

namespace FlyBuy.Controllers
{

    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin , Users")]
        public  ActionResult NewHomePage()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ViewData["Products"] = db.Products.ToList();
            ViewData["Rating"] = db.Rating.ToList();
            ViewData["Offer"] = db.Products.Where(i => i.Description == "Offer").FirstOrDefault();
            ViewData["LatestProducts"] = db.Products.OrderByDescending(i => i.LastUpdated).ToList();
            ViewData["AgeCategories"] = db.AgeCategories.ToList();

            return View();
        }

        [AllowAnonymous]
        public  ActionResult FirstPage()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}