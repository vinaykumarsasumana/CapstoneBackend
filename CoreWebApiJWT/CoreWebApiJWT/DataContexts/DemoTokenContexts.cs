using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class DemoTokenContexts : DbContext
    {
        public DemoTokenContexts()
        {
        }

        public DemoTokenContexts(DbContextOptions<DemoTokenContexts> options)
            : base(options)
        {
        }

        public virtual DbSet<BuyerLogin> BuyerLogins { get; set; }
        public virtual DbSet<BuyerRegistration> BuyerRegistrations { get; set; }
        public virtual DbSet<CartTable> CartTables { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductTable> ProductTables { get; set; }
        public virtual DbSet<SellerLogin> SellerLogins { get; set; }
        public virtual DbSet<SellerRegistration> SellerRegistrations { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=5400-TI11982\\MSSQLSERVER1;Database=ShoppingCapstoneDB ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BuyerLogin>(entity =>
            {
                entity.ToTable("BuyerLogin");

                entity.Property(e => e.BuyerPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.BuyerLogins)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__BuyerLogi__Buyer__4316F928");
            });

            modelBuilder.Entity<BuyerRegistration>(entity =>
            {
                entity.HasKey(e => e.BuyerRegId)
                    .HasName("PK__BuyerReg__BC9A9849D4B20853");

                entity.ToTable("BuyerRegistration");

                entity.Property(e => e.BuyerAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BuyerPassword)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BuyerState)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CartTable>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__CartTabl__51BCD7B78931A0DC");

                entity.ToTable("CartTable");

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.CartTables)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__CartTable__Buyer__4AB81AF0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartTables)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartTable__Produ__4BAC3F29");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderTab__C3905BAFC7BEDEE7");

                entity.ToTable("OrderTable");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BuyerAddress).HasMaxLength(255);

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.BuyerState).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.DeliverCharge).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Mobile).HasMaxLength(255);

                entity.Property(e => e.Pincode).HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.TotalPrice).HasMaxLength(255);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.OrderTables)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__OrderTabl__Buyer__45F365D3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderTables)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderTabl__Produ__47DBAE45");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.OrderTables)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__OrderTabl__Selle__46E78A0C");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.ProductImageId).HasColumnName("ProductImageID");

                entity.Property(e => e.ImageCaption).HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductImageUrl).HasColumnName("ProductImageURL");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductIm__Image__3E52440B");
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__ProductT__B40CC6CD4831F6B3");

                entity.ToTable("ProductTable");

                entity.Property(e => e.ProductBrandName).HasMaxLength(255);

                entity.Property(e => e.ProductDescription).HasMaxLength(1000);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductSubType).HasMaxLength(255);

                entity.Property(e => e.ProductTermsandCondition).HasMaxLength(1000);

                entity.Property(e => e.ProductType).HasMaxLength(255);

                entity.Property(e => e.ProductionCountryOrigin).HasMaxLength(255);

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.ProductTables)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__ProductTa__Selle__3B75D760");
            });

            modelBuilder.Entity<SellerLogin>(entity =>
            {
                entity.ToTable("SellerLogin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SellerPassword).HasMaxLength(255);

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.SellerLogins)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__SellerLog__Selle__38996AB5");
            });

            modelBuilder.Entity<SellerRegistration>(entity =>
            {
                entity.HasKey(e => e.SellerRegId)
                    .HasName("PK__SellerRe__D9353F70BF526156");

                entity.ToTable("SellerRegistration");

                entity.Property(e => e.SellerRegId).HasColumnName("SellerRegID");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.CompanyUrl)
                    .HasMaxLength(255)
                    .HasColumnName("CompanyURL");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("FirstNAME");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MobileNo).HasMaxLength(255);

                entity.Property(e => e.SellerAddress).HasMaxLength(255);

                entity.Property(e => e.SellerPassword).HasMaxLength(255);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Wishlist__51BCD7B708501C77");

                entity.ToTable("Wishlist");

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductPrice).HasMaxLength(255);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Wishlist__OneIma__4E88ABD4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Wishlist__Produc__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
