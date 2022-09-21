using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cart.Business.Models;
using Cart.Data.Mappings;

namespace Cart.Data.Context
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }   
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Address>(new AddressMapping());
            //modelBuilder.ApplyConfiguration<Product>(new ProductMapping());
            //modelBuilder.ApplyConfiguration<Supplier>(new SupplierMapping());
                

            //type relation tables default
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            //type field banco default
            foreach (var propertype in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p=>p.ClrType == typeof(string))))
            {
                propertype.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CartDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
