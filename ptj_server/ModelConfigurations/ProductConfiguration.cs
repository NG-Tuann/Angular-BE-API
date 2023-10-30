using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");

            builder.HasKey(e => e.Id)
                .HasName("PK_PRODUCT");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Active).HasColumnName("ACTIVE");

            builder.Property(e => e.BestSeller).HasColumnName("BEST_SELLER");

            builder.Property(e => e.CatId)
                .HasColumnName("CAT_ID").IsRequired(false);

            builder.Property(e => e.Color)
                .HasMaxLength(12)
                .HasColumnName("COLOR").IsRequired(false);

            builder.Property(e => e.GeomancyId)
                .HasColumnName("GEOMANCY_ID").IsRequired(false);

            builder.Property(e => e.HomeFlag).HasColumnName("HOME_FLAG");

            builder.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IMAGE");

            builder.Property(e => e.MainStoneId)
                .HasColumnName("MAIN_STONE_ID")
                .IsRequired(false);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");

            builder.Property(e => e.Note)
                .HasMaxLength(250)
                .HasColumnName("NOTE").IsRequired(false);

            builder.Property(e => e.SubStoneId)
                    .HasColumnName("SUB_STONE_ID")
                    .IsRequired(false);

            builder.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_PRODUCTS_CATEGORY_PRODUCTS")
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Geomancy)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.GeomancyId)
                .HasConstraintName("FK_PRODUCTS_GEOMANCIES")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MainStone)
                .WithMany(p => p.ProductMainStones)
                .HasForeignKey(d => d.MainStoneId)
                .HasConstraintName("FK__PRODUCTS__MAIN_S__3C34F16F")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.SubStone)
                .WithMany(p => p.ProductSubStones)
                .HasForeignKey(d => d.SubStoneId)
                .HasConstraintName("FK__PRODUCTS__SUB_ST__3D2915A8")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

