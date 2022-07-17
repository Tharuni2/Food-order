using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Food_order.Models
{
    public partial class FoodorderContext : DbContext
    {
        public FoodorderContext()
        {
        }

        public FoodorderContext(DbContextOptions<FoodorderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public IEnumerable<object> AdminDetails { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5F356EVJ\\MYSQLSERVER;Database=Food order;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.Property(e => e.Userid).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Customerid).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Menuid).ValueGeneratedNever();

                entity.Property(e => e.FoodCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasColumnName("Menu_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Orderid).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_Order Item_1");

                entity.ToTable("Order Item");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.Menuid)
                    .HasConstraintName("FK_Order Item_Menu");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("FK_Order Item_Order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Paymentid).ValueGeneratedNever();

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.PaidBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("FK_Payment_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
