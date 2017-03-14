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
                var collection = db.Bidies.ToList();
                foreach (var item in collection)
                {
                    Console.WriteLine(String.Format("{0,-10}{1,-10}{2,-10}{3,10}"
                        ,item.Id,item.IdAccount,item.IdProduct,item.Price));
                }

                var collection2 = db.Bidies.Join(
                        db.Products,
                        b => b.
                    );

                foreach (var item in collection2)
                {
                    Console.WriteLine("{0,-10}");
                }
            }

        }
    }
}
