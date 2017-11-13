using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    /// <summary>
    /// Can hold an object and an error code to better handle exceptions
    /// </summary>
    public class ReturnResult
    {
        public int err { get; set; }
        public object data { get; set; }

    }
}