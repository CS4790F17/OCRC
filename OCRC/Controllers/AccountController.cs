using OCRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OCRC.Controllers
{
  
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult RegisterUser()
        {
            //Finding a user by id 
            if (Repo.findUserById(1).returnCode == 0)
            {
                User user = (User)Repo.findUserById(1).data;
            }
            return View();
        }

        public ActionResult ForgotPassword()
        {
            ViewBag.Message = "Forgot Password.";

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
            Models.Users test = new Models.Users();
            return View(test);
        }

        [HttpPost]
        public ActionResult Login(Models.Users user)
        {
       
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.email, user.password))
                {
                   ///SiteMapResolveEventHandler
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
    }
}