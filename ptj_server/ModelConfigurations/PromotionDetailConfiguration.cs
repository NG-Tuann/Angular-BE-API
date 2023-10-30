using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class PromotionDetailConfiguration : IEntityTypeConfiguration<PromotionDetail>
    {
        public void Configure(EntityTypeBuilder<PromotionDetail> builder)
        {
            builder.ToTable("PROMOTION_DETAILS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_PROMOTION_DETAIL");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .IsRequired(false);

            builder.Property(e => e.PromotionId)
                .HasColumnName("PROMOTION_ID")
                .IsRequired(false);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.PromotionDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_PROMOTION_DETAIL_CUSTOMERS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Promotion)
                .WithMany(p => p.PromotionDetails)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK_PROMOTION_DETAIL_PROMOTIONS")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

