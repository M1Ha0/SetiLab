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
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
