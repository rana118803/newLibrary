using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class issuedbookdetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: issuedbookdetails

        public ActionResult Index()
        {

            return View(db.tblissuedbookdetails.ToList());
        }

        // GET: issuedbookdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblissuedbookdetails tblissuedbookdetails = db.tblissuedbookdetails.Find(id);
            if (tblissuedbookdetails == null)
            {
                return HttpNotFound();
            }
            return View(tblissuedbookdetails);
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
