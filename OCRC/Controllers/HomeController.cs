﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;

namespace OCRC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Nas
        public PartialViewResult _KidDetails()
        {
            Kid kid = new Kid();
            kid.fname = "some";
            kid.lname = "lsome";
            kid.grade = 3;
            kid.school = "MIT";

            return PartialView(kid);
        }
        

        //Yi Lao (Ming)-------------------------
        public ActionResult Result()
        {
            ViewBag.Message = "this is the result page";
            
            return View();
        }
    }
}