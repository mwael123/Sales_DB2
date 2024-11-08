using Microsoft.EntityFrameworkCore;
using Sales_DB2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Sales_DB2;

namespace Sales_DB2.Data
{
    internal class ApplicationDB_CONTEXT : DbContext
    {
        public DbSet<Product> product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-UTQ37J8;Initial Catalog=EF509;Integrated Security=True;TrustServerCertificate=True");

        }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                
                modelBuilder.Entity<Product>(entity =>
                {
                    entity.HasKey(p => p.ProductId);
                    entity.Property(p => p.Name)
                          .IsRequired()
                          .HasMaxLength(50)
                          .IsUnicode(true);
                    entity.Property(p => p.Quantity)
                          .IsRequired()
                          .HasColumnType("decimal(18, 2)");
                    entity.Property(p => p.Price)
                          .IsRequired()
                          .HasColumnType("decimal(18, 2)");
                });

                
                modelBuilder.Entity<Customer>(entity =>
                {
                    entity.HasKey(c => c.CustomerId);
                    entity.Property(c => c.Name)
                          .IsRequired()
                          .HasMaxLength(100)
                          .IsUnicode(true);
                    entity.Property(c => c.Email)
                          .IsRequired()
                          .HasMaxLength(80)
                          .IsUnicode(false);
                    entity.Property(c => c.CreditCardNumber)
                          .IsRequired();
                });

                
                modelBuilder.Entity<Store>(entity =>
                {
                    entity.HasKey(s => s.StoreId);
                    entity.Property(s => s.Name)
                          .IsRequired()
                          .HasMaxLength(80)
                          .IsUnicode(true);
                });

              
                modelBuilder.Entity<Sale>(entity =>
                {
                    entity.HasKey(s => s.SaleId);

                    
                    entity.HasOne(s => s.Product)
                          .WithMany(p => p.Sales)
                          .HasForeignKey(s => s.ProductId)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(s => s.Customer)
                          .WithMany(c => c.Sales)
                          .HasForeignKey(s => s.CustomerId)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(s => s.Store)
                          .WithMany(st => st.Sales)
                          .HasForeignKey(s => s.StoreId)
                          .OnDelete(DeleteBehavior.Restrict);
                });
            }
        }



    }

