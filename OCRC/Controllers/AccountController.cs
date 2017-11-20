using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCRC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult RegisterUser()
        {
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

        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }
    }
}