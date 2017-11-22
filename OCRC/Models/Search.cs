using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCRC.Models
{

    public class Search
    {

        public String fname { get; set; }
        public String lname { get; set; }
        public int year { get; set; }
        public List<Ranking> rank { get; set; }
       
        public static List<Search> getSearchResultsForActive()
        {
            
            List<Search> searchResults = new List<Search>();
            List<Kid> kids = OCRC_API.getAllKids();
            List<Registration> reg = OCRC_API.getAllRegistrations();
            List<Ranking> allrankings = Repo.getAllRankings();
            

            foreach (var kid in kids)
            {
                Search s = new Search();


                Status status = Repo.findStatusById(kid.kidID);
                if (status == null)
                {
                    status = new Status();
                    status.kidIdentifier = kid.kidID;
                    status.active = "active";
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    searchResults.Add(s);
                }
                if (status.active.Equals("active"))
                {
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    s.year = OCRC_API.registrationYear(kid.kidID);
             
                    foreach(var Ranking in allrankings)
                    {
                        if(status.statusID == Ranking.statusID)
                        {
                            s.rank.Add(Ranking);
                        }
                    }

                    searchResults.Add(s);
                }

            }

            return searchResults;
        }




    }
}