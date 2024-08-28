using clnbilling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace clnbilling.CLNDbcontext
{
    public partial class clnDbcontext:DbContext
    {
        public clnDbcontext() 
        {
        }

        public clnDbcontext(DbContextOptions <clnDbcontext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country", "dbo");
                entity.Property(e => e.id)
                .HasColumnName("id");
                entity.Property(e => e.name)
                .HasColumnName("name");
                entity.Property(e => e.is_active)
                .HasColumnName("is_active");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client", "dbo");
                entity.Property(e => e.id) 
                .HasColumnName("id");
                entity.Property(e => e.code)
                .HasColumnName("code");
                entity.Property(e => e.first_name)
                .HasColumnName("first_name");
                entity.Property(e => e.middle_name)
                .HasColumnName("middle_name");
                entity.Property(e => e.last_name1)
                .HasColumnName("last_name1");
                entity.Property(e => e.last_name2)
                .HasColumnName("last_name2");
                entity.Property(e => e.age)
                .HasColumnName("age");
                entity.Property(e => e.country_id)
                .HasColumnName("country_id");
                entity.Property(e => e.state)
                .HasColumnName("state");
                entity.Property(e => e.address_line1)
                .HasColumnName("address_line1");
                entity.Property(e => e.address_line2)
                .HasColumnName("address_line2");
                entity.Property(e => e.email)
                .HasColumnName("email");
                entity.Property(e => e.phone)
                .HasColumnName("phone");
                entity.Property(e => e.phone_extension)
                .HasColumnName("phone_extension");
                entity.Property(e => e.postal_code)
                .HasColumnName("postal_code");
                entity.Property(e => e.is_active)
                .HasColumnName("is_active");
                entity.Property(e => e.created_date)
                .HasColumnName("created_date");
                entity.Property(e => e.last_updated_date)
                .HasColumnName("last_updated_date");
            });

            modelBuilder.Entity<Product>(entity => 
            {
                entity.ToTable("products", "dbo");
                entity.Property(e => e.id)
                .HasColumnName("id");
                entity.Property(e => e.sku)
                .HasColumnName("sku");
                entity.Property(e => e.name)
                .HasColumnName("name");
                entity.Property(e => e.description)
                .HasColumnName("description");
                entity.Property(e => e.country_id)
                .HasColumnName("country_id");
                entity.Property(e => e.currency)
                .HasColumnName("currency");
                entity.Property(e => e.amount)
                .HasColumnName("amount");
                entity.Property(e => e.is_active)
                .HasColumnName("is_active");
            });

            modelBuilder.Entity<Exchange_rate>(entity => 
            {
                entity.ToTable("exchange_rate", "dbo");
                entity.Property(e => e.id)
                .HasColumnName("id");
                entity.Property(e => e.currency)
                .HasColumnName("currency");
                entity.Property(e => e.sale_rate)
                .HasColumnName("sale_rate");
                entity.Property(e => e.registered)
                .HasColumnName("registered");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction", "dbo");
                entity.Property(e => e.id)
                .HasColumnName("id");
                entity.Property(e => e.country_id)
                .HasColumnName("country_id");
                entity.Property(e => e.code)
                .HasColumnName("code");
                entity.Property(e => e.client_id)
                .HasColumnName("client_id");
                entity.Property(e => e.product_id)
                .HasColumnName("product_id");
                entity.Property(e => e.exchange_rate)
                .HasColumnName("exchange_rate");
                entity.Property(e => e.registered)
                .HasColumnName("registered");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public virtual DbSet<Client> Client { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public DbSet<Exchange_rate> Exchange_rate { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
