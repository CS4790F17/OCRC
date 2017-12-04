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

 

        public JsonResult notMyAction(int value)
        {
            

            Search s = new Search { fname = "Ajax", lname = "Ajax", age = 2 };
            SearchViewModel svm = new SearchViewModel();

            svm.searches = Search.getSearchResultsForActive();
            svm.allOfThem = Repo.getSeachesPerRank(svm.searches);

            List<Search> res = new List<Search>();



            svm.sports = OCRC_API.getAllSports();
            foreach (var item in  svm.allOfThem)
            {
                if(item.age == value)
                {
                    res.Add(item);
                }
             }

           

            return new JsonResult { Data = new { n = res } };
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