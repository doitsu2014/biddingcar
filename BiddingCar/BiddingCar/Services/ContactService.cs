using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;
using BiddingCar.Repositories;

namespace BiddingCar.Services
{
    public class ContactService
    {
        ContactRepository repo = new ContactRepository();

        public void AddContact(Contact newContact)
        {
            repo.Add(newContact);
        }

    }
}