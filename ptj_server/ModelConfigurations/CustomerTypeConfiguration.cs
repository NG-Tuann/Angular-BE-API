using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.ToTable("CUSTOMER_TYPES");

            builder.HasKey(e => e.Id)
                .HasName("PK_CUSTOMER_TYPE");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CustomerTypeName)
                    .HasMaxLength(30)
                    .HasColumnName("CUSTOMER_TYPE_NAME");

            builder.Property(e => e.DiscountUnit)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("DISCOUNT_UNIT")
                .IsFixedLength(true);

            builder.Property(e => e.DiscountValue)
                .HasColumnName("DISCOUNT_VALUE");


        }
    }
}

