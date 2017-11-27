using OCRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace OCRC.Controllers
{

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
        public ActionResult Login()
        {
            Models.UserLogin test = new Models.UserLogin();
            return View(test);
        }

        [HttpPost]
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

        public ActionResult ResetPassword(string rt)
        {
            ResetPasswordModel model = new ResetPasswordModel();
            model.ReturnToken = rt;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(Models.UserLogin user)
        {
            if (ModelState.IsValid)
            {
                MembershipUser users;
                using (var context = new UsersContext())
                {
                    var foundUserName = (from u in context.UserProfiles
                                         where u.Email == user.email
                                         select u.UserName).FirstOrDefault();
                    if (foundUserName != null)
                    {
                        users = Membership.GetUser(foundUserName.ToString());
                    }
                    else
                    {
                        users = null;
                    }
                }
                if (users != null)
                {
                    // Generae password token that will be used in the email link to authenticate user
                    var token = WebSecurity.GeneratePasswordResetToken(users.Email);
                    // Generate the html link sent via email
                    string resetLink = "<a href='"
                       + Url.Action("ResetPassword", "Account", new { rt = token }, "http")
                       + "'>Reset Password Link</a>";

                    // Email stuff
                    string subject = "Reset your password for asdf.com";
                    string body = "You link: " + resetLink;
                    string from = "donotreply@asdf.com";

                    MailMessage message = new MailMessage(from, user.email);
                    message.Subject = subject;
                    message.Body = body;
                    SmtpClient client = new SmtpClient();

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

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool resetResponse = WebSecurity.ResetPassword(model.ReturnToken, model.Password);
                if (resetResponse)
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