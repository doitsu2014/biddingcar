using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiddingCar.Models;

namespace BiddingCar.Repositories
{
    interface IAccountRepository
    {
        Account FindAccountByUnameAndPass(string username, string pass);
        Account FindAccountByUname(string username);
        Account FindAccountByEmail(string email);
    }
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public Account FindAccountByEmail(string email)
        {
            using (var db = new AssignmentDBEntities())
            {
                var result = db.Accounts.Where(a => a.Email == email);
                return result.Count() > 0 ? result.First() : null;
            }
        }

        public Account FindAccountByUname(string username)
        {
            using (var db = new AssignmentDBEntities())
            {
                var result = db.Accounts.Where(a => a.Username == username);
                return result.Count() > 0 ? result.First() : null;
            }
        }

        public Account FindAccountByUnameAndPass(string username, string pass)
        {
            using (var db = new AssignmentDBEntities())
            {
                var result = db.Accounts.Where(a => a.Username == username && a.Password == pass);
                return result.Count() > 0 ? result.First() : null;
            }

        }
    }
}