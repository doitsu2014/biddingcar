using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiddingCar.Models;
using BiddingCar.Services;

namespace BiddingCar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductService service = new ProductService();
            var productList = service.GetAllProduct();
            return View(productList);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}