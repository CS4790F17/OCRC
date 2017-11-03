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

    /* Dummy Database
     * Created Yi Lao (Ming)
     * Modified Heather Wilcox 11/1/2017
     */
     /* Prof. Hilton said to not focus on the database part, just the views and 
      * models functionality until we know more about the database they're using.
    public class DummyDatabase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Something { get; set; }
    }
*/
    public class OCRCDbContext : DbContext
    {

    }
    
}