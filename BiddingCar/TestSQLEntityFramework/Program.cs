using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSQLEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AssignmentDBEntities())
            {
                //var products = from s in db.Products
                //               join sa in db.Bidies on s.IdProduct equals sa.IdProduct
                //               group s by s.IdProduct into g
                //               select new { IdProduct = g.Key, Count = g.Count() };

                //var products = db.Products.ToList();

                //var product = db.Products.Where(p => p.IdProduct == "PRO007").First();

                //var result = from s in products
                //             join sa in db.Bidies on s.IdProduct equals sa.IdProduct
                //             select s;

                var products = (from s in db.Products
                               join sb in db.Bidies on s.IdProduct equals sb.IdProduct
                               join ba in db.Accounts on sb.Username equals ba.Username
                               orderby sb.BidTime descending
                               where s.IdProduct == "PRO007"
                               select new { Product = s, Account = ba, Biddy = sb }).First();

                ProductViewModel pvm = new ProductViewModel();
                

            }

        }
    }
}
