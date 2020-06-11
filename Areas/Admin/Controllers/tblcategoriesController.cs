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
    public class tblcategoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/tblcategories
        public ActionResult Index()
        {
            return View(db.tblcategory.ToList());

        }

        [HttpPost]
        //public ActionResult Index(string SearchTerm)
        //{
        //    List<tblcategory> category;

        //    if (string.IsNullOrEmpty(SearchTerm))
        //    {
        //        category = db.tblcategory.ToList();
        //    }
        //    else
        //    {
        //        category = db.tblcategory.ToList();

        //    }
        //    re
        //}

        //public ActionResult Index(string SearchTerm)
        //{
        //    var moduleV = db.tblcategory.ToList()
        //                .Select(module => new tblcategory
        //                {
        //                    CategoryName = SearchTerm,
        //                    id = module.id,
        //                    CategoryName=,
        //                    Status = module.Status,
        //                    CreationDate = module.CreationDate
        //                });

        //    return View(moduleV);//error
        //}

        // GET: Admin/tblcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = db.tblcategory.Find(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // GET: Admin/tblcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "id,CategoryName,Status,CreationDate,UpdationDate,BookPrice")] tblcategory category)
        {
            if (ModelState.IsValid)
            {
                db.tblcategory.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        // GET: Admin/tblcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = db.tblcategory.Find(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // POST: Admin/tblcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CategoryName,Status,CreationDate,UpdationDate")] tblcategory tblcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcategory);
        }

        // GET: Admin/tblcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = db.tblcategory.Find(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // POST: Admin/tblcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblcategory tblcategory = db.tblcategory.Find(id);
            db.tblcategory.Remove(tblcategory);
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