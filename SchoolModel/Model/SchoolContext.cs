using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolModel
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        // Initalizing these to null! looks weird, but these DbSets will always be initalized
        // by the framework to a non-null value. The compile time null checks want them to
        // either be initialized like this or declared as nullable and since they are actually
        // always initialized by the framework, it would be more inaccurate to declare them as nullable.
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; } = null!;
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; } = null!;
        public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Department");

                entity.HasMany(d => d.People)
                    .WithMany(p => p.Courses)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseInstructor",
                        l => l.HasOne<Person>().WithMany().HasForeignKey("PersonId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CourseInstructor_Person"),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CourseInstructor_Course"),
                        j =>
                        {
                            j.HasKey("CourseId", "PersonId");

                            j.ToTable("CourseInstructor");

                            j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");

                            j.IndexerProperty<int>("PersonId").HasColumnName("PersonID");
                        });
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<OfficeAssignment>(entity =>
            {
                entity.HasKey(e => e.InstructorId);

                entity.ToTable("OfficeAssignment");

                entity.Property(e => e.InstructorId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstructorID");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Instructor)
                    .WithOne(p => p.OfficeAssignment)
                    .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeAssignment_Person");
            });

            modelBuilder.Entity<OnlineCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("OnlineCourse");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnlineCourse)
                    .HasForeignKey<OnlineCourse>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineCourse_Course");
            });

            modelBuilder.Entity<OnsiteCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("OnsiteCourse");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.Days).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnsiteCourse)
                    .HasForeignKey<OnsiteCourse>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnsiteCourse_Course");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Discriminator).HasMaxLength(50);

                entity.Property(e => e.EnrollmentDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId);

                entity.ToTable("StudentGrade");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Grade).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
