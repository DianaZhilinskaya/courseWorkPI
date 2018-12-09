namespace couse.mod
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentModel : DbContext
    {
        public StudentModel()
            : base("name=StudentModel")
        {
        }

        public virtual DbSet<Autorization> Autorization { get; set; }
        public virtual DbSet<Count_of_students> Count_of_students { get; set; }
        public virtual DbSet<Curators> Curators { get; set; }
        public virtual DbSet<Form_of_education> Form_of_education { get; set; }
        public virtual DbSet<Group_students> Group_students { get; set; }
        public virtual DbSet<Information_about_student_families> Information_about_student_families { get; set; }
        public virtual DbSet<Needing_social_protection> Needing_social_protection { get; set; }
        public virtual DbSet<Orphan_students> Orphan_students { get; set; }
        public virtual DbSet<Place_of_residence> Place_of_residence { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Students_all> Students_all { get; set; }
        public virtual DbSet<Students_id> Students_id { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autorization>()
                .Property(e => e.login_user)
                .IsUnicode(false);

            modelBuilder.Entity<Autorization>()
                .Property(e => e.password_user)
                .IsUnicode(false);

            modelBuilder.Entity<Count_of_students>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Count_of_students1)
                .HasForeignKey(e => e.count_of_students);

            modelBuilder.Entity<Curators>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Form_of_education>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Form_of_education1)
                .HasForeignKey(e => e.form_of_education);

            modelBuilder.Entity<Group_students>()
                .Property(e => e.faculty)
                .IsUnicode(false);

            modelBuilder.Entity<Group_students>()
                .HasMany(e => e.Students_id)
                .WithOptional(e => e.Group_students1)
                .HasForeignKey(e => e.group_students);

            modelBuilder.Entity<Information_about_student_families>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Information_about_student_families1)
                .HasForeignKey(e => e.information_about_student_families);

            modelBuilder.Entity<Needing_social_protection>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Needing_social_protection1)
                .HasForeignKey(e => e.needing_social_protection);

            modelBuilder.Entity<Orphan_students>()
                .HasMany(e => e.Needing_social_protection)
                .WithOptional(e => e.Orphan_students1)
                .HasForeignKey(e => e.orphan_students);

            modelBuilder.Entity<Place_of_residence>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Place_of_residence1)
                .HasForeignKey(e => e.place_of_residence);

            modelBuilder.Entity<Students_all>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Students_id>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Students_id>()
                .HasOptional(e => e.Students)
                .WithRequired(e => e.Students_id1);
        }
    }
}
