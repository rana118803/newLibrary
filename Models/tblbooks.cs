namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblbooks")]
    public partial class tblbooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string BookName { get; set; }

        public int? CatId { get; set; }
        public virtual tblcategory Category { get; set; }

        public int? AuthorId { get; set; }
        public virtual tblauthors Authors { get; set; }
        public int? ISBNNumber { get; set; }

        public int? BookPrice { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RegDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdationDate { get; set; }
    }
}
