using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCRC.Models;

namespace OCRC.Controllers
{
    public class CoachController : Controller
    {
        public ActionResult Index()
        {
            Repo.CoachDataModel model = new Repo.CoachDataModel();
            model.getCoachName = "Name";

            return View(model);
        }

    }
}