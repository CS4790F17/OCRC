using OCRC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;


namespace OCRC.Controllers
{
    ///[Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult UserList()
        {
            ViewBag.Message = "UserList";

            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            Models.UserLogin test = new Models.UserLogin();
            return View(test);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.UserLogin user)
        {

            if (ModelState.IsValid)
            {
                if (user.IsValid(user.email, 1, user.password))
                {
                    ///SiteMapResolveEventHandler
                    FormsAuthentication.SetAuthCookie(user.email, user.rememberme);
                    return RedirectToAction("Result", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int userId { get; set; }
            public string email { get; set; }  // Add this
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string rt)
        {
            ResetPasswordModel model = new ResetPasswordModel();
            model.ReturnToken = rt;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordModel forgot)
        {
            if (ModelState.IsValid)
            {
                if (forgot.IsValid(forgot.email))
                    {
                    // Generae password token that will be used in the email link to authenticate user
                    string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    // Generate the html link sent via email
                    string resetLink = "<a href='"
                       + Url.Action("ResetPassword", "Account", new { rt = token }, "http")
                       + "'>Reset Password Link</a>";

                    // Email stuff
                    string subject = "Reset your password for" + forgot.email;
                    string body = "Please click this clink to reset your password: " + resetLink;
                    string from = "hoangcao@mail.weber.edu";

                    MailMessage message = new MailMessage(from, forgot.email);
                    message.Subject = subject;
                    message.Body = body;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential("hoangcao@mail.weber.edu", "Thikim22"),
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };

                    // Attempt to send the email
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", "Issue sending email: " + e.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No user found by that email.");
                }
            }
          
            return View(forgot);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
            
                if (model.IsValid(model.Password, model.ConfirmPassword, model.ReturnToken))
                {
                    ViewBag.Message = "Successfully Changed";
                }
                else
                {
                    ViewBag.Message = "Something went horribly wrong!";
                }
            }
            return View(model);
        }
    }
}