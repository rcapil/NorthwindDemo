using NorthwindProducts.Core.Interfaces.Service;
using NorthwindProducts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindProducts.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var productViewModel = new ProductViewModel();
            productViewModel.Products = _productService.GetAllProducts().ToList();

            return View(productViewModel);
        }
    }
}