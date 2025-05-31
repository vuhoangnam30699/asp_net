using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppTransaction.Models;

public partial class T2301eSem3Context : DbContext
{
    public T2301eSem3Context()
    {
    }

    public T2301eSem3Context(DbContextOptions<T2301eSem3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrencyExchange> CurrencyExchanges { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VuHoangNam;Initial Catalog=T2301E_SEM3;User ID=sa;Password=1234567890;MultipleActiveResultSets=True;Application Name=EntityFramework;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrencyExchange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currency__3213E83F05BE0060");

            entity.ToTable("CurrencyExchange");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Currency).HasColumnName("currency");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB99005EB82D");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.GradeId, "IX_Students_GradeId");

            entity.HasOne(d => d.Grade).WithMany(p => p.Students).HasForeignKey(d => d.GradeId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC27455B0B31");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
