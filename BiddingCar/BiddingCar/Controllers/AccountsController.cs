using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiddingCar.Models;
using BiddingCar.Services;

namespace BiddingCar.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var userSession = Session["USER"];
            if (userSession != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AccountService service = new AccountService();
            Account acc = service.FindByUsernameAndPass(username, password);

            var userSession = Session["USER"];
            if (userSession == null)
            {

                if (acc != null)
                {
                    Session["USER"] = acc;
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Logout()
        {
            Session["USER"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string email, string fullname)
        {
            AccountService service = new AccountService();
            Account acc = service.FindByUsername(username);
            Account acc2 = service.FindByEmail(email);
            if (acc != null)
            {
                ViewBag.DuplicateUserMessage = "User duplicate";
                return View();
            }
            else if (acc2 != null)
            {
                ViewBag.DuplicateEmailMessage = "Email duplicate";
                return View();
            }

            Account newAccount = new Account();
            newAccount.Username = username;
            newAccount.Password = password;
            newAccount.Email = email;
            newAccount.Name = fullname;

            service.AddNewAccount(newAccount);

            return RedirectToAction("Login", "Accounts");
        }

        public ActionResult SeeDetails()
        {
            return View();
        }
    }
}