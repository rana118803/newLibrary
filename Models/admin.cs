namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(100)]
        [Display(Name = "FullName")]
        public string FullName { get; set; }
       
        [StringLength(120)]
        [Display(Name = "AdminEmail")]
        [DataType(DataType.EmailAddress)]
        public string AdminEmail { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "adPassword")]
        [DataType(DataType.Password)]
        public string adPassword { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime updationDate { get; set; }
    }
}