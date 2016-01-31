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
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(CreateAccountViewModel createAccount)
        {
            /// make sure that all the fields are there, if not return proper err
            if(createAccount == null)
            {
                ModelState.AddModelError("", "Information is required to create a new account");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.FirstName))
            {
                ModelState.AddModelError("", "First Name is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.LastName))
            {
                ModelState.AddModelError("", "Last name is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.Email))
            {
                ModelState.AddModelError("", "Email is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.Gender))
            {
                ModelState.AddModelError("", "Gender is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.UserName))
            {
                ModelState.AddModelError("", "Username is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.Password))
            {
                ModelState.AddModelError("", "Password is required");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createAccount.Password_conf))
            {
                ModelState.AddModelError("", "Please confirm password");
                return View();
            }
            if(createAccount.Password != createAccount.Password_conf)
            {
                ModelState.AddModelError("", "The passwords do not match");
                return View();
            }
            return Content("Hello, " + createAccount.UserName + " thank you for creating an account, here is everything you told me about your self: Password: " + createAccount.Password +
                ", Email: " + createAccount.Email + ", gender: " + createAccount.Gender + ", Name: " + createAccount.FirstName + " " + createAccount.LastName);
            /// go to proper page if everything is there.
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
}