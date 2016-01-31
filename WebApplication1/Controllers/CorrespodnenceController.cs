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
            //validate contact message input
            if(contactMessage == null)
            {
                ModelState.AddModelError("","no message provided");
                return View();
            }
            if(string.IsNullOrWhiteSpace(contactMessage.Name) || string.IsNullOrWhiteSpace(contactMessage.Email) || string.IsNullOrWhiteSpace(contactMessage.Message))
            {
                ModelState.AddModelError("", "All Fields are required");
                return View();
            }

            //create an email messge object
            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();

            email.To.Add("llcoole93@yahoo.com");
            email.From = new System.Net.Mail.MailAddress(contactMessage.Email);
            email.Subject = "Correspondence Team";
            email.Body = string.Format(
                "Name: {0}\r\nMessage: {1}",
                    contactMessage.Name,
                    contactMessage.Message
                );

            email.IsBodyHtml = false;

            //setup smtp client
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            smtpClient.Host = "smtp.fuse.net";

            //send messge

            smtpClient.Send(email);

            //notify the user the messge was sent
            return View("EmailConfimation");
        }
    }
}