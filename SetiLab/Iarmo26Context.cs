using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SetiLab.Models;

namespace SetiLab;

public partial class Iarmo26Context : DbContext
{
    public Iarmo26Context()
    {
        Database.EnsureCreated();
    }

    public Iarmo26Context(DbContextOptions<Iarmo26Context> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lector> Lectors { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TeacherPC;Initial Catalog=Iarmo26;User ID=user7;Password=user7;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Group>(entity =>
        //{
            //entity.HasKey(e => e.CodeGroup).HasName("Code_group");

            //entity.Property(e => e.CodeGroup).HasColumnName("Code_group");
            //entity.Property(e => e.NameGroup)
            //    .HasMaxLength(100)
            //    .HasColumnName("Name_group");
            //entity.Property(e => e.NameSpeciality)
            //    .HasMaxLength(100)
            //    .HasColumnName("Name_speciality");
            //entity.Property(e => e.NumCourse).HasColumnName("Num_course");
            OnModelCreatingPartial(modelBuilder);
        //});

        //    modelBuilder.Entity<Lector>(entity =>
        //    {
        //        entity.HasKey(e => e.CodeLector).HasName("Code_lector");

        //        entity.Property(e => e.CodeLector).HasColumnName("Code_lector");
        //        entity.Property(e => e.NameLector)
        //            .HasMaxLength(100)
        //            .HasColumnName("Name_lector");
        //        entity.Property(e => e.Post).HasMaxLength(100);
        //        entity.Property(e => e.Science).HasMaxLength(100);
        //    });

        //    modelBuilder.Entity<Progress>(entity =>
        //    {
        //        entity.HasKey(e => e.CodeProgress).HasName("Code_progress");

        //        entity.ToTable("Progress");

        //        entity.Property(e => e.CodeProgress).HasColumnName("Code_progress");
        //        entity.Property(e => e.CodeLector).HasColumnName("Code_lector");
        //        entity.Property(e => e.CodeStud).HasColumnName("Code_stud");
        //        entity.Property(e => e.CodeSubject).HasColumnName("Code_subject");
        //        entity.Property(e => e.DateExam).HasColumnName("Date_exam");
        //    });

        //    modelBuilder.Entity<Student>(entity =>
        //    {
        //        entity.HasKey(e => e.CodeStud).HasName("Code_stud");

        //        entity.Property(e => e.CodeStud).HasColumnName("Code_stud");
        //        entity.Property(e => e.CodeGroup).HasColumnName("Code_group");
        //        entity.Property(e => e.Lastname).HasMaxLength(100);
        //        entity.Property(e => e.Name).HasMaxLength(100);
        //        entity.Property(e => e.Phone).HasColumnType("numeric(38, 0)");
        //        entity.Property(e => e.Surname).HasMaxLength(100);

        //        entity.HasOne(d => d.CodeGroupNavigation).WithMany(p => p.Students)
        //            .HasForeignKey(d => d.CodeGroup)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("Students_Groups_FK");
        //    });

        //    modelBuilder.Entity<Subject>(entity =>
        //    {
        //        entity.HasKey(e => e.CodeSubject).HasName("Code_subject");

        //        entity.Property(e => e.CodeSubject).HasColumnName("Code_subject");
        //        entity.Property(e => e.CountHours).HasColumnName("Count_hours");
        //        entity.Property(e => e.NameSubject)
        //            .HasMaxLength(100)
        //            .HasColumnName("Name_subject");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
