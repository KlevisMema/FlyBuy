using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyBuy.Models;
using FlyBuy.Controllers;

namespace FlyBuy.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext de = new ApplicationDbContext();
        // GET: ShoppingCart

        private int IsExisting(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int i =0; i < cart.Count  ; i++)
            {
                if(cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Delete(int id)
        {
            int index = IsExisting(id);
            List<Cart> cart = (List<Cart>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");
        }

        public ActionResult Index()
        {
            return View("Cart");
        }

        public ActionResult OrderNow(int id)
        {
            if(Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart(de.Products.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                int index = IsExisting(id);
                if(index == -1)
                {
                    cart.Add(new Cart(de.Products.Find(id), 1));
                }
                else
                {
                    cart[index].Quantity++;
                    Session["cart"] = cart;
                }
                    
            }

            if(Session["cart"] == null)
            {
                return RedirectToAction("Index");
            }
           
            return View("Cart");
        }

        public ActionResult CheckOut()
        {
            return View("Cart");
        }

        public ActionResult LastProcessCheckOut(FormCollection frm_coll)
        {
            List<Cart> stCart = (List<Cart>)Session["Cart"];

            var order = new FlyBuy.Models.Order()
            {
                CustomerName = frm_coll["Name"],
                CustomerPhone = frm_coll["Phone"],
                CustomerEmail = frm_coll["Email"],
                CustomerAddress = frm_coll["Adress"]
            };

            de.Orders.Add(order);
            de.SaveChanges();

            foreach (Cart cart in stCart)
            {
                OrderDetails orderDetail = new OrderDetails()
                {
                    OrderId = order.Id,
                    ProductId = cart.Product.Id,
                    Quantity = cart.Quantity,
                    Price = (float)cart.Product.Price
                };
                de.OrderDetails.Add(orderDetail);
                de.SaveChanges();
            }
            Session.Remove("Cart");

            return View();
        }
    }
}