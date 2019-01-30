using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingCartDbContext _dbContext;
        public List<string> Images = new List<string>() {"image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg"};

        public ProductController(ShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Cart = LocalData.Cart;
            ViewBag.Images = Images;

            return View(await _dbContext.Products.ToListAsync());
        }

        public ActionResult Init()
        {
            Product product = _dbContext.Products.FirstOrDefault();

            if(product == null)
            {
                int count = 0;
                int price = 50;
                string name = "My Product";
                while (count < 12)
                {
                    Product p = new Product();
                    p.Name = name + (count + 1);
                    price = (price + (count * 20));
                    p.Price = price.ToString();

                    _dbContext.Products.Add(p);
                    _dbContext.SaveChanges();

                    count++;
                }
            }

            return RedirectToAction("Index");
        }
    
        public ActionResult AddToCart(int id)
        {
            Product product = _dbContext.Products.Find(id);

            Cart cart = LocalData.Cart.Where(i => i.Product.Id == product.Id).FirstOrDefault();
        
            if (cart == null)
            {
                Cart c = new Cart();
                c.Product = product;
                c.Amount = 1;
                LocalData.Cart.Add(c);
            }
            else
            {
                cart.Amount += 1;
            }

            return RedirectToAction("Index");
        }
    
        public ActionResult Expand()
        {
            return RedirectToAction("Index", "Cart");
        }
    }
}