using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactModels c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();

                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.IsBodyHtml = false;


                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential("sdportfolio.travel@gmail.com", "DrEaM oN :P");

                    msg.To.Add("sdportfolio.travel@gmail.com");
                    msg.From = from;
                    msg.Subject = "Contact Us";
                    sb.Append("Name: " + c.Name);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Message: " + c.Comment);
                    msg.Body = sb.ToString();
                    client.Send(msg);
                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View();
        }
    }
}