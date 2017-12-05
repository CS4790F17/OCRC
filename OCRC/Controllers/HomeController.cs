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

 

        public JsonResult filterSearch(String[] sport, int age,int grade,String year,String school)
        {
            //check if Json requested or return null;

            List<Search> result = Repo.filterSearches(sport,age, grade,year,school);

            return new JsonResult { Data = new { n = result} };
        }
        

        //Yi Lao (Ming)-------------------------
        public ActionResult Result()
        {
            SearchViewModel svm = new SearchViewModel();
            svm.sports = OCRC_API.getAllSports();
            svm.searches = Search.getSearchResultsForActive();
            svm.allOfThem = Repo.getSeachesPerRank(svm.searches);

            return View(svm);
        }
    }
}