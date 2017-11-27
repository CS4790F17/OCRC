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