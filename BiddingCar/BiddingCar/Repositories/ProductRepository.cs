using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;

namespace BiddingCar.Repositories
{
    interface IProductRepository
    {
        Product FindProductByCode(string code);

        List<Product> GetTop3Product();
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public Product FindProductByCode(string code)
        {
            using (var db = new AssignmentDBEntities())
            {
                return db.Set<Product>().Find(code);
            }
        }

        public List<Product> GetTop3Product()
        {
            using (var db = new AssignmentDBEntities())
            {
                return db.Set<Product>().OrderByDescending( prop => prop.TimeBegin ).Take(3).ToList();
            }
        }
    }
}