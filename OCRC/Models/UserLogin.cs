using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OCRC.Models;


namespace OCRC.Models
{
    public class ResetPasswordModel
    {
        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "New password and confirmation does not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ReturnToken { get; set; }
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "We need your email to send you a reset link!")]
        [Display(Name = "User name")]
        [EmailAddress(ErrorMessage = "Not a valid email--what are you trying to do here?")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int accesslvl { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool rememberme { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string _email, int _accesslvl, string _password)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|OCRC.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string _sql = @"SELECT [email] FROM [dbo].[User] " +
                       @"WHERE [email] = @u AND [password] = @p AND [accesslvl] = @s";
                 var cmd = new SqlCommand(_sql, cn);
                 cmd.Parameters
                     .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                     .Value = _email;
                cmd.Parameters
                     .Add(new SqlParameter("@s", SqlDbType.Int))
                     .Value = _accesslvl;
                cmd.Parameters
                     .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                     .Value = SHA1.Encode(_password);
                 cn.Open();
                 var reader = cmd.ExecuteReader();
                 if (reader.HasRows)
                 {
                     reader.Dispose();
                     cmd.Dispose();
                     return true;
                 }
                 else
                 {
                     reader.Dispose();
                     cmd.Dispose();
                     return false;
                 }
            }
        }
    }
}