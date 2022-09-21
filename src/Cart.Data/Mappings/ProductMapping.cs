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
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Description)
                .HasColumnType("text");

            builder.Property(p => p.Image)
                .HasColumnType("text");

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");


            builder.ToTable("produtos");
            

        }
    }
}
