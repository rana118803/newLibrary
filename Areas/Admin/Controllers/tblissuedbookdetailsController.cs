using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Areas.Admin.Controllers
{
    public class tblissuedbookdetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/tblissuedbookdetails
        public ActionResult Index()
        {
            return View(db.tblissuedbookdetails.ToList());
        }

        // Get and save Fine in database
        public ActionResult Update(int? id, string fine)
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

            int p = Int32.Parse(fine);
            tblissuedbookdetails.fine = p;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/tblissuedbookdetails/Details/5
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

        // GET: Admin/tblissuedbookdetails/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Admin/tblissuedbookdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "BookId,StudentID,IssuesDate")] tblissuedbookdetails tblissuedbookdetails)
        {
            if (ModelState.IsValid)
            {
                db.tblissuedbookdetails.Add(tblissuedbookdetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblissuedbookdetails);
        }

        // GET: Admin/tblissuedbookdetails/Edit/5
        public ActionResult Edit(int? id)
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


        // POST: Admin/tblissuedbookdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BookId,StudentID,IssuesDate,ReturnDate,RetrunStatus,fine")] tblissuedbookdetails tblissuedbookdetails)
        {
            if (ModelState.IsValid)
            {
                if (tblissuedbookdetails.id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblissuedbookdetails tblissuedbookdetailsobj = db.tblissuedbookdetails.Find(tblissuedbookdetails.id);
                if (tblissuedbookdetails == null)
                {
                    return HttpNotFound();
                }

                tblissuedbookdetailsobj.fine = tblissuedbookdetails.fine;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblissuedbookdetails);
        }

        // GET: Admin/tblissuedbookdetails/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/tblissuedbookdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblissuedbookdetails tblissuedbookdetails = db.tblissuedbookdetails.Find(id);
            db.tblissuedbookdetails.Remove(tblissuedbookdetails);
            db.SaveChanges();
            return RedirectToAction("Index");
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
