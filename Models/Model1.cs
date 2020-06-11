namespace LibraryManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblauthors> tblauthors { get; set; }
        public virtual DbSet<tblbooks> tblbooks { get; set; }
        public virtual DbSet<tblcategory> tblcategory { get; set; }
        public virtual DbSet<tblissuedbookdetails> tblissuedbookdetails { get; set; }
        public virtual DbSet<tblstudents> tblstudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.AdminEmail)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.adPassword)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.updationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblauthors>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<tblauthors>()
                .Property(e => e.creationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblauthors>()
                .Property(e => e.UpdationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblbooks>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<tblbooks>()
                .Property(e => e.RegDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblbooks>()
                .Property(e => e.UpdationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblcategory>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblcategory>()
                .Property(e => e.CreationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblcategory>()
                .Property(e => e.UpdationDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblissuedbookdetails>()
                .Property(e => e.StudentID)
                .IsUnicode(false);

            modelBuilder.Entity<tblissuedbookdetails>()
                .Property(e => e.IssuesDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblissuedbookdetails>()
                .Property(e => e.ReturnDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.StudentId)
                .IsUnicode(false);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.MobileNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.RegDate)
                .HasPrecision(0);

            modelBuilder.Entity<tblstudents>()
                .Property(e => e.UpdationDate)
                .HasPrecision(0);
            modelBuilder.Entity<tblstudents>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<tblissuedbookdetails>().Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
