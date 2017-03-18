using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;

namespace BiddingCar.Repositories
{
    interface IProductRepository
    {
        List<Product> GetTop3Product();
        Product FindProductByIdProduct(string code);
        ProductViewModel FindProductsWithTopBider(string IdProduct);
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public Product FindProductByIdProduct(string code)
        {
            using (var db = new AssignmentDBEntities())
            {
                List<Product> products = db.Products.Where(p => p.IdProduct == code).ToList();
                if(products.Count() > 0)
                {
                    return products.First();
                }else
                {
                    return null;
                }

            }
        }

        public ProductViewModel FindProductsWithTopBider(string IdProduct)
        {
            using (var db = new AssignmentDBEntities())
            {

                var result = (from s in db.Products
                              join sb in db.Bidies on s.IdProduct equals sb.IdProduct
                              join ba in db.Accounts on sb.Username equals ba.Username
                              orderby sb.BidTime descending
                              where s.IdProduct == IdProduct
                              select new { Product = s, Account = ba, Biddy = sb });
                
                if (result.Count() > 0)
                {
                    ProductViewModel pvm = new ProductViewModel();
                    pvm.IdProduct = result.First().Product.IdProduct;
                    pvm.Name = result.First().Product.Name;
                    pvm.MinPrice = result.First().Product.MinPrice;
                    pvm.BaseDescription = result.First().Product.BaseDescription;
                    pvm.TimeBegin = result.First().Product.TimeBegin;
                    pvm.TimeEnd = result.First().Product.TimeEnd;
                    pvm.MinPriceStep = result.First().Product.MinPriceStep;
                    pvm.ImageURL = result.First().Product.ImageURL;
                    pvm.FirstPrice = result.First().Product.FirstPrice;
                    pvm.CategoryID = result.First().Product.CategoryID;
                    pvm.TopPrice = result.First().Product.TopPrice;
                    pvm.BidyCount = result.First().Product.BidyCount;
                    pvm.Status = result.First().Product.Status;
                    pvm.TopBider = result.First().Account.Name;
                    return pvm;
                }
                else
                {
                    return null;
                }

            }
        }

        public List<Product> GetTop3Product()
        {
            using (var db = new AssignmentDBEntities())
            {
                return db.Set<Product>().OrderByDescending(prop => prop.TimeBegin).Take(3).ToList();
            }
        }


    }
}