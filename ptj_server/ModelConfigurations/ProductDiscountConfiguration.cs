using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.ToTable("PRODUCT_DISCOUNTS");

            builder.HasKey(e => e.Id)
                .HasName("PK_PRODUCT_DISCOUNT");

            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

            builder.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("DATE_CREATED")
                    .IsRequired(false);

            builder.Property(e => e.DiscountUnit)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("DISCOUNT_UNIT")
                .IsFixedLength(true);

            builder.Property(e => e.DiscountValue).HasColumnName("DISCOUNT_VALUE");

            builder.Property(e => e.ProductId)
                .HasColumnName("PRODUCT_ID")
                .IsRequired(false);

            builder.Property(e => e.ValidUntil)
                .HasColumnType("date")
                .HasColumnName("VALID_UNTIL")
                .IsRequired(false);

            builder.Property(e => e.Active).HasColumnName("ACTIVE");

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME")
                .IsRequired(false);

            builder.Property(e => e.GemId)
                .HasColumnName("GEM_ID")
                .IsRequired(false);

            builder.Property(e => e.StoneId)
                .HasColumnName("STONE_ID")
                .IsRequired(false);

            builder.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDiscounts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PRODUCT_DISCOUNTS_PRODUCTS")
                    .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(d => d.Geomancy)
                .WithMany(p => p.ProductDiscounts)
                .HasForeignKey(d => d.GemId)
                .HasConstraintName("FK_pdc_gem")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.StoneType)
                .WithMany(p => p.ProductDiscounts)
                .HasForeignKey(d => d.StoneId)
                .HasConstraintName("FK_pdc_stone")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}