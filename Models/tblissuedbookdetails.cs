namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblissuedbookdetails
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        public int? BookId { get; set; }

        [StringLength(150)]
        public string StudentID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? IssuesDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReturnDate { get; set; }

        public int? RetrunStatus { get; set; }

        public int? fine { get; set; }
    }
}
