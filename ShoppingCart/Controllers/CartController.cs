using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers {

    public class CartController : Controller
    {
        private readonly ShoppingCartDbContext _dbContex;
        public static string Message;
        public CartController (ShoppingCartDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        public IActionResult Index()
        {
            int totalPrice = 0;

            foreach(Cart cart in LocalData.Cart)
            {
                totalPrice += Int32.Parse(cart.Product.Price) * cart.Amount;
            }
            
            ViewBag.TotalPrice = totalPrice;
            ViewBag.Message = Message;

            return View(LocalData.Cart);
        }

        public ActionResult Remove(int id)
        {
            var cart = LocalData.Cart.Where(i => i.Product.Id == id).FirstOrDefault();

            if(cart == null)
            {
                return RedirectToAction("Index");
            }

            if(cart.Amount == 1)
            {
                LocalData.Cart.Remove(cart);
            } else
            {
                cart.Amount -= 1;
            }

            return RedirectToAction("Index");
        }

        public ActionResult CheckOut()
        {
            int totalPrice = 0;

            foreach(Cart cart in LocalData.Cart)
            {
                totalPrice += Int32.Parse(cart.Product.Price) * cart.Amount;
            }

            Order order = new Order
            {
                Paid = false,
                Price = totalPrice.ToString()
            };

            _dbContex.Orders.Add(order);

            foreach(Cart cart in LocalData.Cart)
            {
                OrderDetails orderDetails = new OrderDetails
                {
                    OrderId = order.Id,
                    ProductId = cart.Product.Id,
                    Amount = cart.Amount
                };

                _dbContex.OrderDetails.Add(orderDetails);
            }

            _dbContex.SaveChanges();
            LocalData.Cart.Clear();
            Message = "Your order has been placed. Your order ID is: " + order.Id;

            return RedirectToAction("Index");
        }
    }
}