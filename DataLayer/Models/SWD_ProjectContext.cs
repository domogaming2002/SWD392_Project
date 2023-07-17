using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SWD392_Project.Models
{
    public partial class SWD_ProjectContext : DbContext
    {
        public SWD_ProjectContext()
        {
        }

        public SWD_ProjectContext(DbContextOptions<SWD_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryDrug> CategoryDrugs { get; set; } = null!;
        public virtual DbSet<CategoryMedicine> CategoryMedicines { get; set; } = null!;
        public virtual DbSet<Drug> Drugs { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                              .SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataConnectString"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDrug>(entity =>
            {
                entity.ToTable("CategoryDrug");

                entity.Property(e => e.CategoryDrugId).HasColumnName("categoryDrugId");

                entity.Property(e => e.CategoryDrugName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoryDrugName");
            });

            modelBuilder.Entity<CategoryMedicine>(entity =>
            {
                entity.ToTable("CategoryMedicine");

                entity.Property(e => e.CategoryMedicineId).HasColumnName("categoryMedicineId");

                entity.Property(e => e.CategoryMedicineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoryMedicineName");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.ToTable("Drug");

                entity.Property(e => e.DrugId).HasColumnName("drugId");

                entity.Property(e => e.CategoryDrugId).HasColumnName("categoryDrugId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.DrugName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("drugName");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unit");

                entity.HasOne(d => d.CategoryDrug)
                    .WithMany(p => p.Drugs)
                    .HasForeignKey(d => d.CategoryDrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drug_CategoryDrug");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Drugs)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drug_Users");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.MedicineId).HasColumnName("medicineId");

                entity.Property(e => e.CategoryMedicineId).HasColumnName("categoryMedicineId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("medicineName");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unit");

                entity.HasOne(d => d.CategoryMedicine)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.CategoryMedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_CategoryMedicine");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_Users");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.ReportId).HasColumnName("reportId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("datetime")
                    .HasColumnName("description");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("reportName");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("roleId");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
