using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Repositories;

namespace BiddingCar.Services
{
    public class BidyService
    {
        BidyRepository repo = new BidyRepository();

        public int GetCountBidyByProId(string code)
        {
            return repo.CountBidOfProduct(code);
        }

    }
}