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
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //throw new NotImplementedException();

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Complemento)
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(a => a.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(a => a.Bairro)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(a => a.Cidade)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.ToTable("Address");



        }
    }
}
