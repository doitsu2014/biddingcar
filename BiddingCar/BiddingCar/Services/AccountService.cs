using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;
using BiddingCar.Repositories;

namespace BiddingCar.Services
{
    public class AccountService
    {
        AccountRepository repo = new AccountRepository();

        public Account FindByUsernameAndPass(string username, string password)
        {
            return repo.FindAccountByUnameAndPass(username,password);
        }

        public Account FindByUsername(string username)
        {
            return repo.FindAccountByUname(username);
        }

        public Account FindByEmail(string email)
        {
            return repo.FindAccountByEmail(email);
        }

        public void AddNewAccount(Account newAccount)
        {
            repo.Add(newAccount);
        }
    }
}