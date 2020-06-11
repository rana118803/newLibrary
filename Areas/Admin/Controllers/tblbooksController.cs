using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Areas.Admin.Controllers
{
    public class tblbooksController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/tblbooks
        public ActionResult Index()

        {
            var book = db.tblbooks.Include(p => p.Category);
            var book1 = db.tblbooks.Include(p => p.Authors);
            return View(book.ToList());
            return View(book1.ToList());
        }

        // GET: Admin/tblbooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblbooks tblbooks = db.tblbooks.Find(id);
            if (tblbooks == null)
            {
                return HttpNotFound();
            }
            return View(tblbooks);
        }

        // GET: Admin/tblbooks/Create
        public ActionResult Create()
        {
            ViewBag.CatId = new SelectList(db.tblcategory, "id", "CategoryName");
            ViewBag.AuthorId = new SelectList(db.tblauthors, "id", "AuthorName");
            return View();
        }

        // POST: Admin/tblbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblbooks books)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            string sqlquery = "insert into [dbo].[tblbooks] (BookName,CatId,AuthorId,ISBNNumber,BookPrice) values (@BookName,@CatId,@AuthorId,@ISBNNumber,@BookPrice)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlcon);
            sqlcon.Open();
            sqlcomm.Parameters.AddWithValue("@BookName", books.BookName);
            sqlcomm.Parameters.AddWithValue("@CatId", books.CatId);
            sqlcomm.Parameters.AddWithValue("@AuthorId", books.AuthorId);
            sqlcomm.Parameters.AddWithValue("@ISBNNumber", books.ISBNNumber);
            sqlcomm.Parameters.AddWithValue("@BookPrice", books.BookPrice);
            sqlcomm.ExecuteNonQuery();
            sqlcon.Close();
            return View(books);
        }

        // GET: Admin/tblbooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblbooks tblbooks = db.tblbooks.Find(id);
            if (tblbooks == null)
            {
                return HttpNotFound();
            }
            return View(tblbooks);
        }

        // POST: Admin/tblbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BookName,CatId,AuthorId,ISBNNumber,BookPrice,RegDate,UpdationDate")] tblbooks tblbooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblbooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblbooks);
        }

        // GET: Admin/tblbooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblbooks tblbooks = db.tblbooks.Find(id);
            if (tblbooks == null)
            {
                return HttpNotFound();
            }
            return View(tblbooks);
        }

        // POST: Admin/tblbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblbooks tblbooks = db.tblbooks.Find(id);
            db.tblbooks.Remove(tblbooks);
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