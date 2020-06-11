using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class HomeViewModel
    {
        public List<tblissuedbookdetails> tblissuedbookdetails { get; set; }
        public List<tblbooks> tblbooks { get; set; }
        public List<tblauthors> tblauthors { get; set; }
        public List<tblcategory> tblcategory { get; set; }
        public List<tblissuedbookdetails> issuedbookReturned { get; set; }
    }
}