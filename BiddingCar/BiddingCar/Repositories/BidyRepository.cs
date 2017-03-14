using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;

namespace BiddingCar.Repositories
{
    interface IBidyRepository
    {
        int CountBidOfProduct(string code);
    }
    public class BidyRepository : BaseRepository<Bidy>, IBidyRepository
    {

        public int CountBidOfProduct(string code)
        {
            using (var db = new AssignmentDBEntities())
            {
                return db.Bidies.Where(p => p.IdProduct == code).GroupBy(f => f.IdProduct)
                    .Select(g => new { name = g.Key, count = g.Count() }).First().count;
            }
        }
    }
}