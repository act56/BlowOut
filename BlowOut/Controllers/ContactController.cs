using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ViewResult Index()
        {
            ViewBag.Support = "< p style = 'font-size:large;' >Please call Support at<strong>(801) 555-1212.</strong> Thank You.</ p >";
            return View("Index", ViewBag.Support);
        }

        public ViewResult Email(string Name, string email)
        {
            ViewBag.Email = "Thank you, " + Name + " we will send an email to " + email;

            return View("Index", ViewBag.Email);
        }

    }
}