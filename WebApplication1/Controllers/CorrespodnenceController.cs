using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Correspondence;

namespace WebApplication1.Controllers
{
    public class CorrespodnenceController : Controller
    {
        // GET: Correspodnence
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactEmailViewModel contactMessage)
        {
            return null;
        }
    }
}