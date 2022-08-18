using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class ShoeShopContext : DbContext
    {
        public ShoeShopContext()
        {
        }

        public ShoeShopContext(DbContextOptions<ShoeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<BillDetail> BillDetails { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Exchange> Exchanges { get; set; } = null!;
        public virtual DbSet<ImportNote> ImportNotes { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<ReviewFile> ReviewFiles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Shoe> Shoes { get; set; } = null!;
        public virtual DbSet<ShoeColor> ShoeColors { get; set; } = null!;
        public virtual DbSet<ShoeFile> ShoeFiles { get; set; } = null!;
        public virtual DbSet<ShoeStore> ShoeStores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QL8G5UP;Database=ShoeShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Account1)
                    .HasName("PK__Account__B0C3AC4778BC5016");

                entity.ToTable("Account");

                entity.Property(e => e.Account1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Account");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleId__398D8EEE");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.DeliveryTime).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bill__CustomerId__5070F446");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Bill__EmployeeId__5165187F");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Bill__PromotionI__52593CB8");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => new { e.BillId, e.ShoeStoreId })
                    .HasName("PK__BillDeta__DBEFEB63608C3DEA");

                entity.ToTable("BillDetail");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__BillI__5629CD9C");

                entity.HasOne(d => d.ShoeStore)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.ShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__ShoeS__571DF1D5");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ShoeStoreId })
                    .HasName("PK__Cart__6EB373D11F258CB0");

                entity.ToTable("Cart");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__CustomerId__4CA06362");

                entity.HasOne(d => d.ShoeStore)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__ShoeStoreI__4D94879B");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Hex)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Account)
                    .HasConstraintName("FK__Customer__Accoun__3C69FB99");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Account)
                    .HasConstraintName("FK__Employee__Accoun__46E78A0C");
            });

            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.ToTable("Exchange");

                entity.Property(e => e.DeliveryTime).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("FK__Exchange__BillId__5AEE82B9");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Exchange__Employ__59FA5E80");

                entity.HasOne(d => d.NewShoeStore)
                    .WithMany(p => p.ExchangeNewShoeStores)
                    .HasForeignKey(d => d.NewShoeStoreId)
                    .HasConstraintName("FK__Exchange__NewSho__5CD6CB2B");

                entity.HasOne(d => d.OldShoeStore)
                    .WithMany(p => p.ExchangeOldShoeStores)
                    .HasForeignKey(d => d.OldShoeStoreId)
                    .HasConstraintName("FK__Exchange__OldSho__5BE2A6F2");
            });

            modelBuilder.Entity<ImportNote>(entity =>
            {
                entity.ToTable("ImportNote");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ImportNotes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__ImportNot__Emplo__5FB337D6");

                entity.HasOne(d => d.ShoeStore)
                    .WithMany(p => p.ImportNotes)
                    .HasForeignKey(d => d.ShoeStoreId)
                    .HasConstraintName("FK__ImportNot__ShoeS__60A75C0F");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Review__Customer__412EB0B6");

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ShoeId)
                    .HasConstraintName("FK__Review__ShoeId__403A8C7D");
            });

            modelBuilder.Entity<ReviewFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ReviewFile");

                entity.Property(e => e.FileType).HasMaxLength(20);

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.HasOne(d => d.Review)
                    .WithMany()
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("FK__ReviewFil__Revie__440B1D61");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.ToTable("Shoe");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Shoe__BrandId__267ABA7A");
            });

            modelBuilder.Entity<ShoeColor>(entity =>
            {
                entity.ToTable("ShoeColor");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ShoeColors)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__ShoeColor__Color__2E1BDC42");

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.ShoeColors)
                    .HasForeignKey(d => d.ShoeId)
                    .HasConstraintName("FK__ShoeColor__ShoeI__2D27B809");
            });

            modelBuilder.Entity<ShoeFile>(entity =>
            {
                entity.ToTable("ShoeFile");

                entity.Property(e => e.FileType).HasMaxLength(20);

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.ShoeFiles)
                    .HasForeignKey(d => d.ShoeId)
                    .HasConstraintName("FK__ShoeFile__ShoeId__33D4B598");
            });

            modelBuilder.Entity<ShoeStore>(entity =>
            {
                entity.ToTable("ShoeStore");

                entity.HasOne(d => d.ShoeColor)
                    .WithMany(p => p.ShoeStores)
                    .HasForeignKey(d => d.ShoeColorId)
                    .HasConstraintName("FK__ShoeStore__ShoeC__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
