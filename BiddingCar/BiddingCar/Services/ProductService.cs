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

    }
}