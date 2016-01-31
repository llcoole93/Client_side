using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.ViewModels.Account;

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
        /// 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginUserViewModel loginUser)
        {
           
            
            //validate username and password is passes (no empties)
            if(loginUser == null)
            {
                ModelState.AddModelError("", "Login is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(loginUser.Username))
            {
                ModelState.AddModelError("", "Username is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(loginUser.Password))
            {
                ModelState.AddModelError("", "Password is required");
                return View();
            }
            //open db

            //hash password

            //query for user based on username and password

            //if invalid, send user error

            //valid, redirect to user profile
            System.Web.Security.FormsAuthentication.SetAuthCookie(loginUser.Username, loginUser.RememberMe);
            return Redirect(FormsAuthentication.GetRedirectUrl(loginUser.Username, loginUser.RememberMe));
        }
    }
    public class CreateAccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}