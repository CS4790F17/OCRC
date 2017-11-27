using OCRC.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace OCRC.Controllers
{
  
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult RegisterUser()
        {
            //TODO: checkboxes school shows school if checked, , coach shows team
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                //TODO:check if exists, can be done on this layer 
                Repo.AddUser(user);
                return RedirectToAction("Result", "Home");

            }

            return View(user);
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
            Users test = new Users();
            return View(test);
        }

        [HttpPost]
        public ActionResult Login(Users user)
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