using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCRC.Models
{
    public class Repo
    {
        // Tim


        // Nas


        // yi


        // Heather
        public class KidDataModel
        {
            public String fname, lname, school, grade, sport;
            public DateTime datecreated, datemodified;
            public int age, rank, year;
            public bool active;

        }

        public class UserDataModel
        {
            public String fname, lname, notes, role;
            public DateTime datecreated, datemodified;
            public int rank;
            public bool active;
        }

        public class LoginDataModel
        {
            public String email, pass;
            public DateTime datecreated, datemodified;
        }

        public class SearchDataModel
        {
            String school, fname, lname;
            int year;
            //Filter filter;

            //public static SearchDataModel search(string school, string fname, string lname, int year, Filter filter)
            public static SearchDataModel search(string school, string fname, string lname, int year)
            {
                //if school exist, if not then
                //if name exist, if not then
                //if year exist, if not then
                //if filter exist
                return new SearchDataModel();
            }
        }
        // Eric


        // Mohammed


        // Hoang


        //Nelson

        public class CoachDataModel
        {
            String fName, lName, sportName, teamName, coachName;
            int year;

            public String getCoachName { get; set; }


        }
    }
}