using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;
using System.Web.Security;

namespace OCRC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Yi Lao (Ming)-------------------------
        public ActionResult Result()
        {
            List<object> passData = new List<object>();
            var allSports = OCRC_API.getAllSports();
            var allKids = OCRC_API.getAllKids();
            passData.Add(allSports);
            passData.Add(allKids);


            return View(passData);
        }
    }
}