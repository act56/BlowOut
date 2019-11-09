using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

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

        [HttpGet]
        public ActionResult ContactUs()
        {

            return View();
        }

        public void SendEmail(string toAddress, string fromAddress,
                      string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    const string email = "ashlynlewis1@gmail.com";
                    const string password = "trashtan143";

                    var loginInfo = new System.Net.NetworkCredential(email, password);


                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(new MailAddress(toAddress));
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtpClient.EnableSsl = true;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = loginInfo;
                            smtpClient.Send(mail);
                        }

                    }

                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }

                }
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    var status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Response.Write("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        //resend
                        //smtpClient.Send(message);
                    }
                    else
                    {
                        Response.Write("Failed to deliver message to {0}"/*,*/
                                          /*t.FailedRecipient*/);
                    }
                }
            }
            catch (SmtpException Se)
            {
                // handle exception here
                Response.Write(Se.ToString());
            }

            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {

                //prepare email
                var toAddress = "someadress@yahoo.co.uk";
                var fromAddress = contact.EmailAddress.ToString();
                var subject = "Test inquiry from " + contact.Name;
                var message = new StringBuilder();
                message.Append("Name: " + contact.Name + "\n");
                message.Append("Email: " + contact.EmailAddress + "\n");
                message.Append("Telephone: " + contact.phone + "\n\n");
                message.Append(contact.message);

                //start email Thread
                var tEmail = new Thread(() =>
               SendEmail(toAddress, fromAddress, subject, message));
                tEmail.Start();
            }
            return View();
        }

        private void SendEmail(string toAddress, string fromAddress, string subject, StringBuilder message)
        {
            throw new NotImplementedException();
        }
    }
}