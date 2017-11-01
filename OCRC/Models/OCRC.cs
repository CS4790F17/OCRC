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
    public class OCRC
    {

        
    }

    //Yi Lao (Ming)--Creat Dummy Date--------------
    public class DummyDate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Something { get; set; }
    }

    public class OCRCDbContext : DbContext
    {

    }
}