using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiddingCar.Models;
using BiddingCar.Services;

namespace BiddingCar.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BidProduct(string txtIdProduct, string txtBidPrice)
        {
            Account currentUser = Session["USER"] as Account;
            if (currentUser != null)
            {
                string username = currentUser.Username;
                double bidPrice = double.Parse(txtBidPrice);

                Bidy bidy = new Bidy();
                bidy.Username = username;
                bidy.BidTime = DateTime.Now;
                bidy.IdProduct = txtIdProduct;
                bidy.Price = bidPrice;

                BidyService service = new BidyService();
                ProductService service2 = new ProductService();
                Product curPro = service2.FindByIdProduct(txtIdProduct);

                if(curPro.TimeEnd > DateTime.Now) {
                    service.AddBiddy(bidy);
                    curPro.TopPrice =  bidPrice;
                    curPro.BidyCount += 1;
                    service2.UpdateProduct(curPro);
                }
                return RedirectToAction("SeeDetail", "Product", new { idProduct = txtIdProduct });
            }else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult SeeDetail(string idProduct)
        {
            ProductService service = new ProductService();
            var result = service.FindProductsWithTopBider(idProduct);
            if (result == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(result);
        }
    }
}