using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    public class ResetPasswordModel
    {
        [Display(Name = "User name")]
        [EmailAddress]
        public string email { get; set; }

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
        public bool IsValid(string _email)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang\CS4790\OCRC\OCRC\App_Data\OCRC.mdf;Integrated Security=True"))
            {
                string _sql = @"SELECT [email] FROM [dbo].[User] " +
                       @"WHERE [email] = @u";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _email;
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
        public bool IsValid(string _ConfirmPassword, string _ReturnToken)
        {
            if (ConfirmPassword == _ConfirmPassword && ReturnToken == _ReturnToken)
                return true;
            else
            {
                return false;
            }
        }
    }
}