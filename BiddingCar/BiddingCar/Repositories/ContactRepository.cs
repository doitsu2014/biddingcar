using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;

namespace BiddingCar.Repositories
{
    interface IContactRepository
    {

    }
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {

    }
}