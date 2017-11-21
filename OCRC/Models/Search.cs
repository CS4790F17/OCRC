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
        public List<Sport> sport { get; set; }
        //adding this to connect which ranking goes with each sport
        public List<Ranking> rank { get; set; }
        public int page { get; set; }
        public int offSet { get; set; }

        //for each student if we have a status then we create a status in the status 

        public static List<Search> getSearchResults()
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

                }
                if (status.active.Equals("active"))
                {
                    s.fname = kid.fname;
                    s.lname = kid.lname;
                    s.year = OCRC_API.registrationYear(kid.kidID);
                    s.sport = OCRC_API.getSportsPerKid(kid.kidID);
                    foreach(var Ranking in allrankings)
                    {
                        if(status.statusID == Ranking.statusID)
                        {
                            s.rank.Add(Ranking);
                        }
                    }
                    

                }

                searchResults.Add(s);

            }

            return searchResults;
        }




    }
}