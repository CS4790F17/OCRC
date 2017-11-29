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
        public String school { get; set; }
       
        public static List<Search> getSearchResultsForActive()
        {
            
            List<Search> searchResults = new List<Search>();
            List<Kid> kids = OCRC_API.getAllKids();
            List<Registration> reg = OCRC_API.getAllRegistrations();
            List<Ranking> allrankings = Repo.getAllRankings();
            

            foreach (var kid in kids)
            {
                Search s = new Search();
                s.rank = new List<Ranking>();
                Ranking r = new Ranking();
                

                Status status = Repo.findStatusById(kid.kidID);
                if (status == null)
                {
                    status = new Status();
                    status.kidIdentifier = kid.kidID.ToString();
                    status.active = "active";
                    status.activityModified = DateTime.Now;
                    Repo.addStatus(status);
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    s.school = kid.school;

                }
                if (status.active.Equals("active"))
                {
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    s.school = kid.school;
                    s.year = OCRC_API.registrationYear(kid.kidID);
             
                    foreach(var Ranking in allrankings)
                    {
                        if(status.statusID == Ranking.statusID)
                        {
                            s.rank.Add(Ranking);
                        }
                    }

                    
                }
                r.statusID = status.statusID;
                r.userID = 1;
                r.dateCreated = DateTime.Now;
                r.rank = 5;
                r.sportType = "Basketball";
                Repo.addRanking(r);
                searchResults.Add(s);

            }

            return searchResults;
        }




    }
}