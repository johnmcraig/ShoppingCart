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
            return View(await _dbContext.Products.ToListAsync());
        }
    }
}