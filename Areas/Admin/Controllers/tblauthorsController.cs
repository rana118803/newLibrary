using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Areas.Admin.Controllers
{
    public class tblauthorsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/tblauthors
        public ActionResult Index()
        {
            return View(db.tblauthors.ToList());
        }

        // GET: Admin/tblauthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblauthors tblauthors = db.tblauthors.Find(id);
            if (tblauthors == null)
            {
                return HttpNotFound();
            }
            return View(tblauthors);
        }

        // GET: Admin/tblauthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblauthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public ActionResult Create(tblauthors authors)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            string sqlquery = "insert into [dbo].[tblauthors] (AuthorName) values (@AuthorName)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlcon);
            sqlcon.Open();
            sqlcomm.Parameters.AddWithValue("@AuthorName", authors.AuthorName);
           
            sqlcomm.ExecuteNonQuery();
            sqlcon.Close();

            return RedirectToAction("Index");
        }
        // GET: Admin/tblauthors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblauthors tblauthors = db.tblauthors.Find(id);
            if (tblauthors == null)
            {
                return HttpNotFound();
            }
            return View(tblauthors);
        }

        // POST: Admin/tblauthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,AuthorName,creationDate,UpdationDate")] tblauthors tblauthors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblauthors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblauthors);
        }

        // GET: Admin/tblauthors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblauthors tblauthors = db.tblauthors.Find(id);
            if (tblauthors == null)
            {
                return HttpNotFound();
            }
            return View(tblauthors);
        }

        // POST: Admin/tblauthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblauthors tblauthors = db.tblauthors.Find(id);
            db.tblauthors.Remove(tblauthors);
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
