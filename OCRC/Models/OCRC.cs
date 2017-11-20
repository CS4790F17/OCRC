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
        //TODO: take care of FKeys when deleting


        /// <summary>
        /// Finds a Note using its Id
        /// </summary>
        /// <param name="id"> Note Id</param>
        /// <returns>A ReturnResult with a Note as data</returns>
        public static ReturnResult findNoteById(int? id)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    var notes = db.Notes.Find(id);
                    return new ReturnResult(ReturnCode.SUCCESS, notes);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        /// <summary>
        /// Finds a ranking by Id
        /// </summary>
        /// <param name="id"> Ranking Id</param>
        /// <returns> A ReturnResult object with a ranking as data</returns>
        public static ReturnResult findRankingById(int? id)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    var ranking = db.Rankings.Find(id);
                    return new ReturnResult(ReturnCode.SUCCESS, ranking);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }


        /// <summary>
        /// Finds a status by id
        /// </summary>
        /// <param name="id"> status Id</param>
        /// <returns> ReturnResult object with a status as data</returns>
        public static ReturnResult findStatusById(int? id)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    var status = db.Statuses.Find(id);
                    return new ReturnResult(ReturnCode.SUCCESS, status);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }


        /// <summary>
        ///  Finds a user using their Id
        /// </summary>
        /// <param name="id"> User's Id</param>
        /// <returns>ReturnResult object with a user as data</returns>
        public static ReturnResult findUserById(int? id)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    var user = db.Users.Find(id);
                    return new ReturnResult(ReturnCode.SUCCESS, user);
                }
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
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    db.Entry(user).State = EntityState.Deleted;
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return new ReturnResult(ReturnCode.SUCCESS, true);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        /// <summary>
        ///  deletes a note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static ReturnResult deleteNote(Notes note)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    db.Entry(note).State = EntityState.Deleted;
                    db.Notes.Remove(note);
                    int c = db.SaveChanges(); //TODO: returns the number of lines affected. handle errors
                    return new ReturnResult(ReturnCode.SUCCESS, true);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }

        /// <summary>
        ///  deletes a status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ReturnResult deleteStatus(Status status)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    db.Entry(status).State = EntityState.Deleted;
                    db.Statuses.Remove(status);
                    db.SaveChanges();
                    return new ReturnResult(ReturnCode.SUCCESS, true);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
            }
        }



        /// <summary>
        /// deletes a ranking
        /// </summary>
        /// <param name="ranking"></param>
        /// <returns></returns>
        public static ReturnResult deleteRanking(Ranking ranking)
        {
            try
            {
                using (OCRCDbContext db = new OCRCDbContext())
                {
                    db.Entry(ranking).State = EntityState.Deleted;
                    db.Rankings.Remove(ranking);
                    db.SaveChanges();
                    return new ReturnResult(ReturnCode.SUCCESS, true);
                }
            }
            catch (Exception e)
            {
                return new ReturnResult(ReturnCode.FAILURE, e.Message);
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

    /// <summary>
    /// TODO: better comments
    /// </summary>
    public class OCRCDbContext : DbContext
    {
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
    }

}