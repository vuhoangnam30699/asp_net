using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppMobile.Models;

public partial class MobileShoppingContext : DbContext
{
    public MobileShoppingContext()
    {
    }

    public MobileShoppingContext(DbContextOptions<MobileShoppingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Mobile> Mobiles { get; set; }

    public virtual DbSet<MobileDetail> MobileDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VuHoangNam;Initial Catalog=MobileShopping;User ID=sa;Password=1234567890;MultipleActiveResultSets=True;Application Name=EntityFramework;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__014881AEAB8AE814");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB993EBA0B99");

            entity.ToTable("Employee");

            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Office).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__300424B4");
        });

        modelBuilder.Entity<Mobile>(entity =>
        {
            entity.HasKey(e => e.SlNo);

            entity.Property(e => e.SlNo).HasColumnName("slNo");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.MobileName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Url)
                .HasMaxLength(350)
                .HasColumnName("url");
            entity.Property(e => e.ZoomUrl).HasMaxLength(350);
        });

        modelBuilder.Entity<MobileDetail>(entity =>
        {
            entity.HasKey(e => e.Slno);

            entity.Property(e => e.Slno).HasColumnName("SLNO");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Features).HasMaxLength(600);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.SimType).HasMaxLength(50);

            entity.HasOne(d => d.Mobile).WithMany(p => p.MobileDetails)
                .HasForeignKey(d => d.MobileId)
                .HasConstraintName("FK_MobileDetails_Mobiles");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0771098A7F");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076D47EE6D");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRoleMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC0723F57E11");

            entity.ToTable("UserRoleMapping");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoleMappings)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoleM__RoleI__31EC6D26");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoleMappings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoleM__UserI__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
