namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblstudents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int id { get; set; }

        [StringLength(100)]
        public string StudentId { get; set; }

        [StringLength(120)]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [StringLength(120)]
        [Display(Name = "EmailId")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [StringLength(11)]
        public string MobileNumber { get; set; }

        [StringLength(120)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RegDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdationDate { get; set; }
    }
}
