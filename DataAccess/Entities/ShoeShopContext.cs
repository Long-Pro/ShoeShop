using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
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
                entity.ToTable("Account");

                entity.HasIndex(e => e.AccountValue, "UQ__Account__85F1D1F8A404171F")
                    .IsUnique();

                entity.Property(e => e.AccountValue)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__RoleId__35BCFE0A");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.DeliveryTime).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bill__CustomerId__4CA06362");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bill__EmployeeId__4D94879B");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Bill__PromotionI__4E88ABD4");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => new { e.BillId, e.ShoeStoreId })
                    .HasName("PK__BillDeta__DBEFEB638C14E98B");

                entity.ToTable("BillDetail");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__BillI__5165187F");

                entity.HasOne(d => d.ShoeStore)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.ShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__ShoeS__52593CB8");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ShoeStoreId })
                    .HasName("PK__Cart__6EB373D1391390F6");

                entity.ToTable("Cart");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__CustomerId__48CFD27E");

                entity.HasOne(d => d.ShoeStore)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__ShoeStoreI__49C3F6B7");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar).HasMaxLength(200);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Accoun__38996AB5");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.IdentityCard, "UQ__Employee__DA5B2F6DF0F686E5")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityCard)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Accoun__440B1D61");
            });

            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.ToTable("Exchange");

                entity.Property(e => e.DeliveryTime).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exchange__BillId__5629CD9C");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exchange__Employ__5535A963");

                entity.HasOne(d => d.NewShoeStore)
                    .WithMany(p => p.ExchangeNewShoeStores)
                    .HasForeignKey(d => d.NewShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exchange__NewSho__5812160E");

                entity.HasOne(d => d.OldShoeStore)
                    .WithMany(p => p.ExchangeOldShoeStores)
                    .HasForeignKey(d => d.OldShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Exchange__OldSho__571DF1D5");
            });

            modelBuilder.Entity<ImportNote>(entity =>
            {
                entity.ToTable("ImportNote");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ImportNotes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportNot__Emplo__5AEE82B9");

                entity.HasOne(d => d.ShoeStore)
                    .WithMany(p => p.ImportNotes)
                    .HasForeignKey(d => d.ShoeStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportNot__ShoeS__5BE2A6F2");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__Customer__3C69FB99");

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__ShoeId__3B75D760");
            });

            modelBuilder.Entity<ReviewFile>(entity =>
            {
                entity.ToTable("ReviewFile");

                entity.Property(e => e.FileType).HasMaxLength(20);

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewFiles)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReviewFil__Revie__403A8C7D");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.ToTable("Shoe");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GenderType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(100);


                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shoe__BrandId__267ABA7A");
            });

            modelBuilder.Entity<ShoeColor>(entity =>
            {
                entity.ToTable("ShoeColor");

                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Hex)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.ShoeColors)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoeColor__ShoeI__29572725");
            });

            modelBuilder.Entity<ShoeFile>(entity =>
            {
                entity.ToTable("ShoeFile");

                entity.Property(e => e.FileType).HasMaxLength(20);

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.HasOne(d => d.Shoe)
                    .WithMany(p => p.ShoeFiles)
                    .HasForeignKey(d => d.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoeFile__ShoeId__2F10007B");
            });

            modelBuilder.Entity<ShoeStore>(entity =>
            {
                entity.ToTable("ShoeStore");

                entity.HasOne(d => d.ShoeColor)
                    .WithMany(p => p.ShoeStores)
                    .HasForeignKey(d => d.ShoeColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoeStore__ShoeC__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
