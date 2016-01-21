using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return this.RedirectToAction("Login");
        }

        /// <summary>
        /// To create account for my application
        /// </summary>
        /// <returns>ViewResult for the create</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Logging users into the web site
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}