﻿using System;
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
        [Required]
        [Display(Name = "User name")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

      
        public string ReturnToken { get; set; }
        public string returnemail(string _email)
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
                return _sql;
            }
        }

        public bool changepassword(string _email, string _NewPassword)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang\CS4790\OCRC\OCRC\App_Data\OCRC.mdf;Integrated Security=True"))
            {
                string _sql = @"UPDATE [dbo].[User] " + @"SET [password] = @v " +
                       @"WHERE [email] = @u";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _email;
                cmd.Parameters
                    .Add(new SqlParameter("@v", SqlDbType.NVarChar))
                    .Value = Helpers.SHA1.Encode(_NewPassword);
                cn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.RecordsAffected ==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool confirm(string _ReturnToken)
        {
            if (ReturnToken == _ReturnToken)
                return true;
            else
            {
                return false;
            }
        }
    }
}