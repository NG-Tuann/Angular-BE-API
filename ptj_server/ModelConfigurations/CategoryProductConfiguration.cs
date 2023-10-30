using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class CategoryProductConfiguration: IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.ToTable("CATEGORY_PRODUCTS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_CATEGORY_PRODUCT");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("NAME");

            builder.Property(e => e.ParentId)
                .HasColumnName("PARENT_ID").IsRequired(false);

            builder.HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_CATEGORY_PRODUCT")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

