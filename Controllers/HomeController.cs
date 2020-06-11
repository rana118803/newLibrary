using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{

    public class HomeController : Controller
    {

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
            //var students = db.tblstudents.ToList();

            var category = db.tblcategory.ToList();
            var viewModel = new HomeViewModel
            {
                //tblstudents = students,
                issuedbookReturned = returened,

                //tblbooks = books,
                tblcategory = category,
                tblissuedbookdetails = issuedbook
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(admin adm)
        {
            if (ModelState.IsValid)
            {
                var details = (from admins in db.admin
                               where admins.UserName == adm.UserName && admins.adPassword == adm.adPassword
                               select new
                               {
                                   admins.id,
                                   admins.UserName
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["id"] = details.FirstOrDefault().id;
                    Session["UserName"] = details.FirstOrDefault().UserName;
                    return RedirectToAction("Index", "Dashbourd", new { id = Session["id"], Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "invalid user name or password");
                }
            }
            return View(adm);
        }

        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*
        public ActionResult UserLogin(tblstudents user)
        {
            if (ModelState.IsValid)
            {
                var details = (from tblstudents in db.tblstudents
                               where tblstudents.EmailId == user.EmailId && tblstudents.Password == user.Password
                               select new
                               {
                                   tblstudents.id,
                                   tblstudents.EmailId
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["id"] = details.FirstOrDefault().id;
                    Session["EmailId"] = details.FirstOrDefault().EmailId;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "invalid user name or password");
                }
            }
            return View(user);
        }
        */
        public ActionResult UserLogin(tblstudents user)
        {
            if (ModelState.IsValid)
            {
                var details = (from tblstudents in db.tblstudents
                               where tblstudents.EmailId == user.EmailId && tblstudents.Password == user.Password
                               select new
                               {
                                   tblstudents.StudentId,
                                   tblstudents.id,
                                   tblstudents.EmailId
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["id"] = details.FirstOrDefault().id;
                    Session["EmailId"] = details.FirstOrDefault().EmailId;
                    Session["StudentId"] = details.FirstOrDefault().StudentId;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "invalid user name or password");
                }
            }
            return View(user);
        }
        public ActionResult logOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}