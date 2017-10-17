using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using static BootstrapSitetestsite.Models.Email;
using System.Net;

namespace BootstrapSitetestsite.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Email()
        {
            return View();
        }

        public ActionResult SendEmail()
        {
            sendEmail();
            return RedirectToAction("Index", "Home");
        }

        protected void sendEmail()
        {
           
        }

        [HttpPost]
        public ActionResult Login(string emailTo, string emailFrom, string emailSubject, string emailBody)
        {
            string s1 = emailFrom;
            string s2 = emailTo.ToString();
            string s3 = emailSubject;
            string s4 = emailBody;

            MailMessage mm = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            
            
            mm.To.Add("dstineback@gmail.com");
            mm.Sender = new MailAddress(s1);
            mm.From = mm.Sender;
            mm.Body = s4;
            mm.Subject = s3;
            mm.IsBodyHtml = true;
            smtp.Host = ("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("dstineback@gmail.com", "Ltj1234567");
            smtp.EnableSsl = true;

            smtp.Send(mm);
           
            return RedirectToAction("Index", "Home");
        }
    }
}