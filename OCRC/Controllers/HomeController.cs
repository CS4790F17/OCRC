using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;

namespace OCRC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Nas
        public PartialViewResult _KidDetails()
        {
            Kid kid = new Kid();
            kid.fname = "some";
            kid.lname = "lsome";
            kid.grade = 3;
            kid.school = "MIT";

            return PartialView(kid);
        }
        

        //Yi Lao (Ming)-------------------------
        public ActionResult Result()
        {
            //var allSports = OCRC_API.getAllSports();
            SearchViewModel svm = new SearchViewModel();
            svm.sports = OCRC_API.getAllSports();
            svm.searches = Search.getSearchResultsForActive();
            return View(svm);
        }
    }
}