using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCRC.Models
{
    public class Repo
    {
        // Tim


        // Nas

        /// <summary>
        /// Finds a user by their Id
        /// </summary>
        /// <param name="id"> a user Id</param>
        /// <returns> A ReturnResult with a User object as data if successful</returns>
        public static ReturnResult findUserById(int? id)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.findUserById(id).data);
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        /// <summary>
        /// Deletes a User
        /// </summary>
        /// <param name="user"> a User object</param>
        /// <returns> a ReturnResult with a data of true if successful</returns>
        public static ReturnResult deleteUser(User user)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS,OCRC.deleteUser(user).data);
                
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }


        public static ReturnResult deleteNote(Notes note)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.deleteNote(note).data);

            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        public static ReturnResult deleteRanking(Ranking ranking)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.deleteRanking(ranking).data);

            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        public static ReturnResult deleteStatus(Status status)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.deleteStatus(status).data);

            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }


        public static ReturnResult findNoteById(int? id)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.findNoteById(id).data);
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }


        public static ReturnResult findRankingById(int? id)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.findRankingById(id).data);
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }
        
        public static ReturnResult findStatusById(int? Id)
        {
            try
            {
                return new ReturnResult(ReturnCode.SUCCESS, OCRC.findStatusById(Id).data);
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }


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

        public class SearchDataModel {
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


    }
}