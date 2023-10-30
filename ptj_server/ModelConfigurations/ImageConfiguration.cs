using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("IMAGES");

            builder.HasKey(e => e.Id)
                .HasName("PK_IMAGE");

            builder.Property(e => e.NameImages)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME_IMAGES")
                    .IsRequired(false); ;

            builder.Property(e => e.IdProduct)
                .HasColumnName("PRODUCT_ID")
                .IsRequired(false);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_IMAGES_PRODUCTS")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

