using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("REVIEWS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_REVIEW");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Content)
                    .HasMaxLength(200)
                    .HasColumnName("CONTENT")
                    .IsRequired(false);

            builder.Property(e => e.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .IsRequired(false);

            builder.Property(e => e.ProductId)
                .HasColumnName("PRODUCT_ID")
                .IsRequired(false);

            builder.Property(e => e.Rate)
                .HasColumnName("RATE")
                .IsRequired(false);

            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("TITLE")
                .IsRequired(false);

            builder.Property(e => e.Created_Date)
                .HasColumnType("date")
                .HasColumnName("CREATED_DATE")
                .IsRequired(false);

            builder.Property(e => e.Is_Update)
                .HasColumnName("IS_UPDATE")
                .IsRequired(false);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_REVIEWS_CUSTOMERS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_REVIEWS_PRODUCTS")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

