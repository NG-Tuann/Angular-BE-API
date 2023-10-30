using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.ToTable("PRODUCT_PRICES");

            builder.HasKey(e => e.Id).HasName("PK_PRODUCT_PRICE");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.BasePrice).HasColumnName("BASE_PRICE");

            builder.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("CREATED_DATE")
                .IsRequired(false);

            builder.Property(e => e.InActive).HasColumnName("IN_ACTIVE").IsRequired(false);

            builder.Property(e => e.SalePrice).HasColumnName("SALE_PRICE");

        }
    }
}

