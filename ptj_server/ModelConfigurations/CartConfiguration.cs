using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("CARTS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_CART");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            //

            builder.Property(e => e.CustomerId)
                    .HasColumnName("CUSTOMER_ID")
                    .IsRequired(false);

            builder.Property(e => e.OrderId)
                .HasColumnName("ORDER_ID")
                .IsRequired(false);

            builder.Property(e => e.ProductDetailId)
                .HasColumnName("PRODUCT_DETAIL_ID")
                .IsRequired(false);

            builder.Property(e => e.Quantity)
                .HasColumnName("QUANTITY")
                .IsRequired(false);

            builder.Property(e => e.Is_Check)
                .HasColumnName("IS_CHECK")
                .IsRequired(false);

            builder.Property(e => e.SavePrice)
                .HasColumnName("SAVEPRICE")
                .IsRequired(false);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CARTS_CUSTOMERS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Order)
                .WithMany(p => p.Carts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_CARTS_ORDER_PRODUCTS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ProductDetail)
                .WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductDetailId)
                .HasConstraintName("FK__CARTS__PRODUCT_D__0697FACD")
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

