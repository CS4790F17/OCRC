using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCRC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult RegisterUser()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            ViewBag.Message = "Forgot Password.";

            return View();
        }

        //GET: /Account/Login
        [AllowAnonymous]
      
        public ActionResult Login(string returnUrl)
        {
            ViewBag.Message = "Login";
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

    }
}