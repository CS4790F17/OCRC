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



        public static Notes findNoteById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var note = db.Notes.Find(id);
                return note;
            }
        }

        public static Ranking findRankingById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var ranking = db.Rankings.Find(id);
                return ranking;
            }
        }

        
        public static Status findStatusById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var status = db.Statuses.Find(id);
                return status;
            }
        }


        public static User findUserById(int? id)
        {
            using (OCRCDbContext db = new OCRCDbContext())
            {
                var user = db.Users.Find(id);
                return user;
            }
        }
        
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
        public int userID { get; set; }
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
        public int userID { get; set; }
        [DisplayName("Date Created")]
        public DateTime dateCreated { get; set; }
        [DisplayName("Rank")]
        public int rank { get; set; }
        [DisplayName("Sport")]
        public String sportType { get; set; }

    }


    /// <summary>
    /// TODO: better comment
    /// </summary>
    [Table("Status")]
    public class Status
    {
        [Key]
        public int statusID { get; set; }
        public int kidIdentifier { get; set; }
        [DisplayName("Kid Status")]
        public String active { get; set; }
        [DisplayName("Modified Date")]
        public DateTime activityModified { get; set; }
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
        public String teamIdentifier { get; set; }

    }


    public class OCRCDbContext : DbContext
    {
       public DbSet<Notes> Notes { get; set; }
       public DbSet<Ranking> Rankings { get; set; }
       public DbSet<Status> Statuses { get; set; }
       public DbSet<User> Users { get; set; }
    }

}