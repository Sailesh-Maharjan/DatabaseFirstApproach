using System;
using System.Collections.Generic;
using DatabaseFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.Data;

public partial class DatabaseFirstApproachContext : DbContext
{
    public DatabaseFirstApproachContext()
    {
    }

    public DatabaseFirstApproachContext(DbContextOptions<DatabaseFirstApproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
     //  => optionsBuilder.UseSqlServer("Server=localhost;Database=DatabaseFirstApproach;Trusted_Connection=True;TrustServerCertificate=True"); // Note: after successfully moving this to
    // connection string appsettings.json. then Delete this warning msg and add {} to  this given method to fix arrived error

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
