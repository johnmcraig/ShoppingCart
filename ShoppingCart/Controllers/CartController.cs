using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;
//using ShoppingCart.Models;

namespace ShoppingCart.Controllers {

    public class CartController : Controller {
        private readonly ShoppingCartDbContext _dbContex;
        public CartController (ShoppingCartDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}