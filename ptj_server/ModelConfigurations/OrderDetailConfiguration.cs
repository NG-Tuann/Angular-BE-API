using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("ORDER_DETAILS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_ORDER_DETAIL");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            //

            builder.Property(e => e.OrderId)
                   .HasColumnName("ORDER_ID")
                   .IsRequired(false);

            builder.Property(e => e.ProductDetailId)
                .HasColumnName("PRODUCT_DETAIL_ID")
                .IsRequired(false);

            builder.Property(e => e.Quantity)
                .HasColumnName("QUANTITY")
                .IsRequired(false);

            builder.Property(e => e.SalePrice)
                .HasColumnName("SALE_PRICE")
                .IsRequired(false);

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__ORDER_DET__ORDER__0A688BB1")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ProductDetail)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductDetailId)
                .HasConstraintName("FK__ORDER_DET__PRODU__0B5CAFEA")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

