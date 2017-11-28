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
        public class Sport
        {
            public int sportID { get; set; }
            public String sportName { get; set; }
        }

        public class Kid
        {
            public int kidID { get; set; }
            public int grade { get; set; }
            public String fname { get; set; }
            public String lname { get; set; }
            public int age { get; set; }
            public String school { get; set; }
        }

        public class Registration
        {
            public int registrationID { get; set; }
            public int registrationYear { get; set; }
            public int kidID { get; set; }
            public DateTime dateRegistered { get; set; }
            public int teamID { get; set; }
        }

        public class Team
        {
            public int teamId { get; set; }
            public int userID { get; set; }
            public int sportID { get; set; }
            public String teamName { get; set; }
        }

        public class PretendData
        {
            public List<Sport> getAllSports()
            {
                List<Sport> sports = new List<Sport>()
                {
                    new Sport {sportID = 1,  sportName = "Basketball"},
                    new Sport{sportID = 2, sportName = "Baseball"},
                    new Sport{sportID = 3, sportName = "Boxing" },
                    new Sport{sportID = 4, sportName = "Fishing"},
                    new Sport{sportID = 5,  sportName = "Soccer"},
                    new Sport{sportID = 6, sportName = "Volleyball"},
                    new Sport{sportID = 7, sportName = "Swimming" },
                    new Sport{sportID = 8, sportName = "Wrestling"},
                    new Sport{sportID = 9, sportName = "Dancing"},
                    new Sport{sportID = 10, sportName = "Football"}

                };
                return sports;
            }
            public List<Kid> getAllKids()
            {
                List<Kid> kids = new List<Kid>()
                {
                    new Kid{kidID = 1, grade = 11, fname = "Eric", lname = "Guapo", age = 16, school = "Weber High"},
                    new Kid{kidID = 2, grade = 12, fname = "Tim", lname = "Boss", age = 17, school = "Ben Lomond High"},
                    new Kid{kidID = 3, grade = 8, fname = "Heather", lname = "Gamer", age = 14, school = "North Ogden Jr"},
                    new Kid{kidID = 4, grade = 7, fname = "Nas", lname = "Hair", age = 14,school = "Mound Fort Jr" },
                    new Kid{kidID = 5, grade = 9, fname = "James", lname = "Bond", age = 15, school = "Mount Ogden Jr"},
                    new Kid{kidID = 6, grade = 10, fname = "Robert", lname = "Hilton", age = 16, school= "Ogden High"},
                    new Kid{kidID = 7, grade = 12, fname = "Bill", lname = "Nye", age = 17, school = "Boneville High"},
                    new Kid{kidID = 8, grade = 11, fname = "Neil", lname = "Tyson", age = 17, school = "Roy High"},
                    new Kid{kidID = 9, grade = 8, fname = "Brian", lname = "Rauge", age = 13, school = "Highland Jr"}
                };
                return kids;
            }

            public List<Registration> getAllRegistrations()
            {
                List<Registration> kids = new List<Registration>()
                {
                    new Registration{registrationID = 1, dateRegistered = new DateTime(2016, 2, 10), registrationYear = 2016, kidID = 1, teamID = 1 },
                    new Registration{registrationID = 2, dateRegistered = new DateTime(2017, 3, 23), registrationYear = 2017, kidID = 1, teamID = 10 },
                    new Registration{registrationID = 3, dateRegistered = new DateTime(2016, 3, 22), registrationYear = 2016, kidID = 1, teamID = 19},
                    new Registration{registrationID = 4, dateRegistered = new DateTime(2016, 5, 3), registrationYear = 2016, kidID = 2, teamID = 2 },
                    new Registration{registrationID = 5, dateRegistered = new DateTime(2015, 6, 15), registrationYear = 2015, kidID = 2, teamID = 20 },
                    new Registration{registrationID = 6, dateRegistered = new DateTime(2016, 7, 15), registrationYear = 2016, kidID = 3, teamID = 3 },
                    new Registration{registrationID = 7, dateRegistered = new DateTime(2016, 11, 13), registrationYear = 2016, kidID = 3, teamID = 12 },
                    new Registration{registrationID = 8, dateRegistered = new DateTime(2016, 1, 4), registrationYear = 2016, kidID = 4, teamID = 4},
                    new Registration{registrationID = 9, dateRegistered = new DateTime(2016, 4, 11), registrationYear = 2016, kidID = 4, teamID = 22 },
                    new Registration{registrationID = 10, dateRegistered = new DateTime(2016, 4, 22), registrationYear = 2016, kidID = 5, teamID = 5 },
                    new Registration{registrationID = 11, dateRegistered = new DateTime(2017, 5, 23), registrationYear = 2017, kidID = 5, teamID = 14 },
                    new Registration{registrationID = 12, dateRegistered = new DateTime(2016, 9, 22), registrationYear = 2016, kidID = 6, teamID = 15},
                    new Registration{registrationID = 13, dateRegistered = new DateTime(2016, 6, 12), registrationYear = 2016, kidID = 7, teamID = 7},
                    new Registration{registrationID = 14, dateRegistered = new DateTime(2015, 8, 15), registrationYear = 2015, kidID = 7, teamID = 16 },
                    new Registration{registrationID = 15, dateRegistered = new DateTime(2016, 9, 1), registrationYear = 2016, kidID = 7, teamID = 25 },
                    new Registration{registrationID = 16, dateRegistered = new DateTime(2016, 12, 13), registrationYear = 2016, kidID = 8, teamID = 8 },
                    new Registration{registrationID = 17, dateRegistered = new DateTime(2017, 3, 4), registrationYear = 2017, kidID = 9, teamID = 9 },
                    new Registration{registrationID = 18, dateRegistered = new DateTime(2016, 4, 11), registrationYear = 2016, kidID = 9, teamID = 27 }

                };
                return kids;
            }

            public List<Team> getAllTeams()
            {
                List<Team> teams = new List<Team>()
                {
                    new Team{teamId = 1, sportID = 1, userID = 1, teamName = "Warriors" },
                    new Team{teamId = 2, sportID = 2, userID = 2, teamName = "Scots" },
                    new Team{teamId = 3, sportID = 3, userID = 3, teamName = "Knights" },
                    new Team{teamId = 4, sportID = 4, userID = 4, teamName = "Bears" },
                    new Team{teamId = 5, sportID = 5, userID = 5, teamName = "Rams" },
                    new Team{teamId = 6, sportID = 6, userID = 6, teamName = "Tigers" },
                    new Team{teamId = 7, sportID = 7, userID = 7, teamName = "Lakers" },
                    new Team{teamId = 8, sportID = 8, userID = 8, teamName = "Royals" },
                    new Team{teamId = 9, sportID = 9, userID = 9, teamName = "Hurricanes" },
                    new Team{teamId = 10, sportID = 10, userID = 10, teamName = "Warriors" },
                    new Team{teamId = 11, sportID = 1, userID = 11, teamName = "Scots" },
                    new Team{teamId = 12, sportID = 2, userID = 12, teamName = "Knights" },
                    new Team{teamId = 13, sportID = 3, userID = 13, teamName = "Bears" },
                    new Team{teamId = 14, sportID = 4, userID = 14, teamName = "Rams" },
                    new Team{teamId = 15, sportID = 5, userID = 15, teamName = "Tigers" },
                    new Team{teamId = 16, sportID = 6, userID = 16, teamName = "Lakers" },
                    new Team{teamId = 17, sportID = 7, userID = 17, teamName = "Royals" },
                    new Team{teamId = 18, sportID = 8, userID = 18, teamName = "Hurricanes" },
                    new Team{teamId = 19, sportID = 9, userID = 19, teamName = "Warriors" },
                    new Team{teamId = 20, sportID = 10, userID = 20, teamName = "Scots" },
                    new Team{teamId = 21, sportID = 1, userID = 21, teamName = "Knights" },
                    new Team{teamId = 22, sportID = 2, userID = 22, teamName = "Bears" },
                    new Team{teamId = 23, sportID = 3, userID = 23, teamName = "Rams" },
                    new Team{teamId = 24, sportID = 4, userID = 24, teamName = "Tigers" },
                    new Team{teamId = 25, sportID = 5, userID = 25, teamName = "Lakers" },
                    new Team{teamId = 26, sportID = 6, userID = 26, teamName = "Royals" },
                    new Team{teamId = 27, sportID = 7, userID = 27, teamName = "Hurricanes" }
                };
                return teams;
            }
        }

        // Mohammed


        // Hoang

        // Nelson
        public class Coach
        {

        }


    }
}