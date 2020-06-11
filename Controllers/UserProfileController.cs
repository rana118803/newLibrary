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
    public class UserProfileController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            List<tblstudents> list = new List<tblstudents>();
            var EmailId = Session["EmailId"];
            foreach (var item in db.tblstudents.ToList())
            {
                if (item.EmailId == EmailId.ToString())
                {
                    list.Add(item);
                }
            }
            return View(list);

            
        }
       
        

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: UserProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,StudentId,FullName,EmailId,MobileNumber,Password,Status,RegDate,UpdationDate")] tblstudents tblstudents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstudents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblstudents);
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