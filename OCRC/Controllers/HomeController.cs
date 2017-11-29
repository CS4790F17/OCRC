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
            svm.allOfThem = new List<Search>();

            //TODO:Move to repo. a method that takes List<Search> and returns List<Search>.
            foreach (var aSearch in svm.searches)
            {
                int z = 0;
                foreach (var x in aSearch.rank)
                {
                    Search s = new Search();
                    s.fname = aSearch.fname;
                    s.lname = aSearch.lname;
                    s.age = aSearch.age;
                    s.grade = aSearch.grade;
                    s.school = aSearch.school;
                    s.rank = new List<Ranking>();
                    s.rank.Add(aSearch.rank[z]);
                    s.year = aSearch.year;
                    z++;
                    
                    svm.allOfThem.Add(s);
                }

            }


            return View(svm);
        }
    }
}