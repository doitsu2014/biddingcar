using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;
using BiddingCar.Repositories;

namespace BiddingCar.Services
{

    public class ProductService
    {
        private ProductRepository repo = new ProductRepository();
        public List<Product> GetAllProduct()
        {
            return repo.GetAll();
        }

        public List<Product> GetTop3Products()
        {
            return repo.GetTop3Product();
        }

        public Product FindByIdProduct(string code)
        {
            return repo.FindProductByIdProduct(code);
        }

        public void UpdateProduct(Product upPro)
        {
            repo.Update(upPro);
        }

        public ProductViewModel FindProductsWithTopBider (string idProduct)
        {
            var result = repo.FindProductsWithTopBider(idProduct);
            if(result != null)
            {
                return result;
            }else
            {
                ProductViewModel pvm = new ProductViewModel();
                var product = repo.FindProductByIdProduct(idProduct);
                if(product != null)
                {
                    pvm.IdProduct = product.IdProduct;
                    pvm.Name = product.Name;
                    pvm.MinPrice = product.MinPrice;
                    pvm.BaseDescription = product.BaseDescription;
                    pvm.TimeBegin = product.TimeBegin;
                    pvm.TimeEnd = product.TimeEnd;
                    pvm.MinPriceStep = product.MinPriceStep;
                    pvm.ImageURL = product.ImageURL;
                    pvm.FirstPrice = product.FirstPrice;
                    pvm.CategoryID = product.CategoryID;
                    pvm.TopPrice = product.TopPrice;
                    pvm.BidyCount = product.BidyCount;
                    pvm.Status = product.Status;
                    pvm.TopBider = "NO ONE";
                    return pvm;
                }

                return null;
                
            }
        }

    }
}