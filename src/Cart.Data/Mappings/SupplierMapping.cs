using Cart.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Data.Mappings
{
    internal class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(s => s.Document)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(s => s.KindSupplier)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(a => a.Address)
                .WithOne(s => s.Supplier);


            builder.HasMany(p => p.Products)
                .WithOne(s => s.Supplier)
                .HasForeignKey(p=>p.SupplierId);

            builder.ToTable("Supplier");
        }
    }
}
