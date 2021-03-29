using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Remont_Kursovoi;

namespace Remont_Kursovoi.Controllers
{
    public class ActionJobsController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: ActionJobs
        public ActionResult Index()
        {
            return View(db.ActionJob.ToList());
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
