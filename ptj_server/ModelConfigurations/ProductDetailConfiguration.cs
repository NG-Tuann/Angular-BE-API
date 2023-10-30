using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("PRODUCT_DETAILS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_PRODUCT_DETAIL");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            //
            builder.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_DATE")
                    .IsRequired(false);

            builder.Property(e => e.ImportQuantity)
                .HasColumnName("IMPORT_QUANTITY")
                .IsRequired(false);

            builder.Property(e => e.ProductId)
                .HasColumnName("PRODUCT_ID")
                .IsRequired(false);

            builder.Property(e => e.ProductPriceId)
                .HasColumnName("PRODUCT_PRICE_ID")
                .IsRequired(false);

            builder.Property(e => e.Quantity)
                .HasColumnName("QUANTITY")
                .IsRequired(false);

            builder.Property(e => e.Size)
                .HasColumnName("SIZE");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__PRODUCT_D__PRODU__625A9A57")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ProductPrice)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductPriceId)
                .HasConstraintName("FK__PRODUCT_D__PRODU__634EBE90")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

