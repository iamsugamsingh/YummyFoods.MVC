using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YummyFoods.Models.DBModelClasses
{
    public partial class YummyFoodsDBContext : DbContext
    {
        public YummyFoodsDBContext()
        {
        }

        public YummyFoodsDBContext(DbContextOptions<YummyFoodsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblCustomerLogin> TblCustomerLogins { get; set; } = null!;
        public virtual DbSet<tblAdmin> tblAdmin { get; set; } = null!;
        public virtual DbSet<TblAdminLogin> TblAdminLogins { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategory { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblProductReviews> TblProductReviews { get; set; } = null!;
        public virtual DbSet<TblProductCart> TblProductCart { get; set; } = null!;
        public virtual DbSet<TblOffersDBModel> tblOffers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Happy;Initial Catalog=YummyFoodsDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__TblCusto__A4AE64D8E2F5B6D0");

                entity.HasIndex(e => e.CustomerEmailId, "UQ__TblCusto__0C1ED7A81F89AD3E")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerContactNo, "UQ__TblCusto__244E85DC39016533")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerEmailId)
                    .HasMaxLength(100)
                    .HasColumnName("CustomerEmailID");

                entity.Property(e => e.CustomerGender).HasMaxLength(6);

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomerLogin>(entity =>
            {
                entity.HasKey(e => e.CustomerLoginId)
                    .HasName("PK__TblCusto__124DFF540B4933C0");

                entity.ToTable("TblCustomerLogin");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerEmailId)
                    .HasMaxLength(100)
                    .HasColumnName("CustomerEmailID");

                entity.Property(e => e.CustomerToken).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
