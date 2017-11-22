using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OCRC.Models
{
    /// <summary>
    /// Contains all the CRUD methods for OCRC models
    /// </summary>
    public class OCRC
    {
        //TODO: add summaries to all methods

        public static Kid findKid(int? id)
        {
            using(OCRCDbContext db = new OCRCDbContext())
            {
                var kid = db.Kids.Find(id);
                return kid;
            }  
        }

        public static Notes findNotes(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var note = db.Notes.Find(id);
                return note;
            }
        }

        public static Ranking findRanking(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var ranking = db.Rankings.Find(id);
                return ranking;
            }
        }

        public static Registration findRegistration(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var registeration = db.Registrations.Find(id);
                return registeration;
            }
        }

        public static Role findRole(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var role = db.Roles.Find(id);
                return role;
            }
        }

        public static School findSchool(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var school = db.Schools.Find(id);
                return school;
            }
        }

        public static Sport findSport(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var sport = db.Sports.Find(id);
                return sport;
            }
        }

        public static Status findStatus(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var status = db.Statuses.Find(id);
                return status;
            }
        }

        public static Team findTeam(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var team = db.Teams.Find(id);
                return team;
            }
        }

        public static User findUser(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var user = db.Users.Find(id);
                return user;
            }
        }





    }

    /// <summary>
    /// a Kid's Model , Represents a Kid's data entry
    /// </summary>
    [Table("Kid")]
    public class Kid
    {
        [Key]
        public int kidID { get; set; }
        [DisplayName("First Name"), Range(3, 50), Required] //TODO: find better ranges?
        public String fname { get; set; }
        [DisplayName("Last Name"), Range(3, 50), Required]
        public String lname { get; set; }

        public int schoolID { get; set; }

        [DisplayName("Grade")]
        public String grade { get; set; }

        [DisplayName("Age")]
        public int age { get; set; }
    }

    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Notes")]
    public class Notes
    {
        [Key]
        public int notesID { get; set; }
        [DisplayName("Created Date")]
        public DateTime dateCreated { get; set; }
        [DisplayName("Modified Date")]
        public DateTime dateModified { get; set; }
        public int statusID { get; set; }
        [DisplayName("Notes")]
        public String notes { get; set; }

    }

    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Ranking")]
    public class Ranking
    {
        [Key]
        public int rankingID { get; set; }
        public int statusID { get; set; }
        [DisplayName("Created Date")]
        public DateTime dateCreated { get; set; }
        [DisplayName("Modified Date")]
        public DateTime dateModified { get; set; }
        [DisplayName("Rank")]
        public int rank { get; set; }
        public int teamID { get; set; }

    }


    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int registrationID { get; set; }
        [DisplayName("Year Registered")]
        public int registrationYear { get; set; }
        public int kidID { get; set; }
        [DisplayName("Registered Date")]
        public DateTime dateRegistered { get; set; }
        public int teamID { get; set; }


    }

    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("School")]
    public class School
    {
        [Key]
        public int schoolID { get; set; }
        [DisplayName("School Name")]
        public String schoolName { get; set; }
        [DisplayName("School Coach")]
        public String schoolCoach { get; set; }
    }


    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Sport")]
    public class Sport
    {
        [Key]
        public int sportID { get; set; }
        [DisplayName("Sport Name")]
        public String sportName { get; set; }

    }


    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Status")]
    public class Status
    {
        [Key]
        public int statusID { get; set; }
        public int kidID { get; set; }
        public int sportID { get; set; }
        [DisplayName("Kid Status")]
        public bool active { get; set; }
        [DisplayName("Modified Date")]
        public DateTime activityModified { get; set; }
    }


    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Team")]
    public class Team
    {
        [Key]
        public int teamID { get; set; }
        public int userID { get; set; }
        [DisplayName("Team Name")]
        public String teamName { get; set; }
        public int sportID { get; set; }

    }


    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("User")]
    public class User
    {
        [Key]
        public int userID { get; set; }
        [DisplayName("First Name")]
        public String fname { get; set; }
        [DisplayName("Last Name")]
        public String lname { get; set; }
        [DisplayName("Email"), EmailAddress]
        public String email { get; set; }
        [DisplayName("Password"), PasswordPropertyText]
        public String password { get; set; } //TODO: save the hash of this password instead of the actual pw
        public int accesslvl { get; set; }

    }


    public class OCRCDbContext : DbContext
    {
       public DbSet<Kid> Kids { get; set; }
       public DbSet<Notes> Notes { get; set; }
       public DbSet<Ranking> Rankings { get; set; }
       public DbSet<Registration> Registrations { get; set; }
       public DbSet<School> Schools { get; set; }
       public DbSet<Sport> Sports { get; set; }
       public DbSet<Status> Statuses { get; set; }
       public DbSet<Team> Teams { get; set; }
       public DbSet<User> Users { get; set; }

    }

}