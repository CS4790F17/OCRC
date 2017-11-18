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
        public static Notes findNoteById(int? id)
        {
            return OCRC.findNotesById(id);
        }

        public static List<Notes> getAllNotes()
        {
            List<Notes> notes = OCRC.getAllNotes();
            return notes;
        }

        public static void addNote(Notes note)
        {
            OCRC.addNote(note);
        }

        public static void setNotesDateModified(DateTime dateModified)
        {
            OCRC.setNotesDateModified(dateModified);
        }

        public static void setNotesDateCreated(DateTime dateCreated)
        {
            OCRC.setNotesDateCreated(dateCreated);
        }

        public static Ranking findRankingById(int? id)
        {
            OCRC.findRankingById(id);
        }

        public static List<Ranking> getAllRankings()
        {
            return OCRC.getAllRankings();
        }

        public static void addRanking(Ranking ranking)
        {
            OCRC.addRanking(ranking);
        }

        public static void setRankingDateCreated(DateTime dateCreated)
        {
            OCRC.setRankingDateCreated(dateCreated);
        }

        public static void setRankingSportType(string sportType)
        {
            OCRC.setRankingSportType(sportType);
        }

        public static Status findStatusById(int? id)
        {
            OCRC.findStatusById(id);
        }

        public static List<Status> getAllStatuses()
        {
            return OCRC.getAllStatuses();
        }

        public static void setStatusKidIdentifier(string kidIdentifier)
        {
            OCRC.setStatusKidIdentifier(kidIdentifier);
        }

        public static void setStatusActive(string active)
        {
            OCRC.setStatusActive(active);
        }

        public static void setStatusActivityModified(DateTime activityModified)
        {
            OCRC.setStatusActivityModified(activityModified);
        }

        public static User findUserById(int? id)
        {
            OCRC.findUserById(id);
        }

        public static List<User> getAllUsers()
        {
            return OCRC.getAllUsers();
        }

        public static void setUserFName(string fname)
        {
            OCRC.setUserFName(fname);
        }

        public static void setUserLName(string lname)
        {
            OCRC.setUserLName(lname);
        }

        public static void setUserEmail(string email)
        {
            OCRC.setUserEmail(email);
        }

        public static void setUserPassword(string password)
        {
            OCRC.setUserPassword(password);
        }

        public static void setUserAccesslvl(string accesslvl)
        {
            OCRC.setUserAccesslvl(accesslvl);
        }

        public static void setUserTeamIdentifier(string teamIdentifier)
        {
            OCRC.setUserTeamIdentifier(teamIdentifier);
        }
        // Eric


        // Mohammed


        // Hoang


        //Nelson


    }
}