using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCSendMail.Models;

public partial class CiitsocialDbContext : DbContext
{
    public CiitsocialDbContext()
    {
    }

    public CiitsocialDbContext(DbContextOptions<CiitsocialDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblstudent> Tblstudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=115.124.106.98;User Id=ciitsocialuser;Password=CIIT#2025;Database=CIITSocialDB;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ciitsocialuser");

        modelBuilder.Entity<Tblstudent>(entity =>
        {
            entity.HasKey(e => e.Rno).HasName("PK__tblstude__C2B7F59B79E98EA2");

            entity.ToTable("tblstudents");

            entity.Property(e => e.Rno).HasColumnName("rno");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.Qualification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("qualification");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
