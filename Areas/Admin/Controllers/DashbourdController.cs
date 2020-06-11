using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Areas.Admin.Controllers
{
    public class DashbourdController : Controller
    {
        // GET: Admin/Home
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            List<tblissuedbookdetails> returened = new List<tblissuedbookdetails>();
            var issuedbook = db.tblissuedbookdetails.ToList();
            foreach (var item in db.tblissuedbookdetails.ToList())
            {
                if (item.ReturnDate != null)
                {
                    returened.Add(item);
                }
            }
            //var books = db.tblbooks.ToList();
            var authors = db.tblauthors.ToList();
            var category = db.tblcategory.ToList();
            var student = db.tblstudents.ToList();

            var viewModel = new HomeViewModel
            {

                issuedbookReturned = returened,
                tblauthors = authors,
                //tblbooks = books,
                tblcategory = category,
                tblissuedbookdetails = issuedbook 
                

            };
            return View(viewModel);
        }
    }
}