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

        
        public ActionResult MyAction(SearchViewModel svm)
        {
            
            Search s = new Search { fname = "Ajax", lname = "Ajax", age = 2 };
            s.rank = new List<Ranking>();
            s.rank.Add(new Ranking {rank=3});
            s.year = 2000;
            svm.allOfThem.Add(s);

            return View("Result",svm);
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