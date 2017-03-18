using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiddingCar.Models;
using BiddingCar.Services;

namespace BiddingCar.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public ActionResult PostContact(string fullname, string email, string content)
        {
            Contact newContact = new Contact();
            newContact.Fullname = fullname;
            newContact.Email = email;
            newContact.ContentMessage = content;
            newContact.DateSend = DateTime.Now;
            ContactService service = new ContactService();
            service.AddContact(newContact);
            return RedirectToAction("Index", "Home");
        }
    }
}