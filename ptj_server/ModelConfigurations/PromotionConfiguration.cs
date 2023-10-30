using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("PROMOTIONS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_PROMOTION");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Code)
                     .HasMaxLength(20)
                     .IsUnicode(false)
                     .HasColumnName("CODE");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION")
                .IsRequired(false);

            builder.Property(e => e.DiscountUnit)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("DISCOUNT_UNIT")
                .IsFixedLength(true);

            builder.Property(e => e.DiscountValue).HasColumnName("DISCOUNT_VALUE");

            builder.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("END_DATE")
                .IsRequired(false);

            builder.Property(e => e.MaxDiscount).
                HasColumnName("MAX_DISCOUNT")
                .IsRequired(false);

            builder.Property(e => e.MinOrder).
                HasColumnName("MIN_ORDER")
                .IsRequired(false);

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");

            builder.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("START_DATE")
                .IsRequired(false);

            builder.Property(e => e.Activate)
                .HasColumnName("ACTIVATE");
        }
    }
}

