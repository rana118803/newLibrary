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
    public class tblstudentsController : Controller
    {
        private readonly Model1 db = new Model1();
        

        // GET: Admin/tblstudents
        public ActionResult Index()
        {
            
            return View(db.tblstudents.ToList());
        }

        [HttpPost]

            // GET: Admin/tblstudents/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstudents tblstudents = db.tblstudents.Find(id);
            if (tblstudents == null)
            {
                return HttpNotFound();
            }
            return View(tblstudents);
        }

        // GET: Admin/tblstudents/Create
        /*public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblstudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,StudentId,FullName,EmailId,MobileNumber,Password,Status,RegDate,UpdationDate")] tblstudents tblstudents)
        {
            if (ModelState.IsValid)
            {
                db.tblstudents.Add(tblstudents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblstudents);
        }

        // GET: Admin/tblstudents/Edit/5
       

        // POST: Admin/tblstudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblstudents students)
        {
            if (ModelState.IsValid)
            {

                var dbUser = db.tblstudents.Find(students.id);

                
              if(students.Status == 0)
                {
                    dbUser.Status = 1;
                }
                else
                {
                    dbUser.Status = 0;
                }

                db.Entry(dbUser).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        
        // GET: Admin/tblstudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstudents tblstudents = db.tblstudents.Find(id);
            if (tblstudents == null)
            {
                return HttpNotFound();
            }
            return View(tblstudents);
        }

        // POST: Admin/tblstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblstudents tblstudents = db.tblstudents.Find(id);
            db.tblstudents.Remove(tblstudents);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Action(tblstudents st)
        {
            st.Status = 0;
            db.Entry(st.Status).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
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


