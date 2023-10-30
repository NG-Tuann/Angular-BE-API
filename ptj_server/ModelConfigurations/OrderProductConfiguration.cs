using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class OrderProductConfiguration:IEntityTypeConfiguration<OrderProduct>
	{
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("ORDER_PRODUCTS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_ORDER_PRODUCT");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            //
            builder.Property(e => e.AddressDelivery)
                    .HasMaxLength(100)
                    .HasColumnName("ADDRESS_DELIVERY");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .IsRequired(false);

            builder.Property(e => e.DateCreated)
                .HasColumnType("date")
                .HasColumnName("DATE_CREATED")
                .IsRequired(false);

            builder.Property(e => e.DatePay)
                .HasColumnType("date")
                .HasColumnName("DATE_PAY")
                .IsRequired(false);

            builder.Property(e => e.IdUser)
                .HasColumnName("ID_USER")
                .IsRequired(false);

            builder.Property(e => e.NameCusNonAccount)
                .HasMaxLength(50)
                .HasColumnName("NAME_CUS_NON_ACCOUNT");

            builder.Property(e => e.OrderState)
                .HasMaxLength(30)
                .HasColumnName("ORDER_STATE");

            builder.Property(e => e.PayType)
                .HasMaxLength(20)
                .HasColumnName("PAY_TYPE");

            builder.Property(e => e.PhoneNonAccount)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PHONE_NON_ACCOUNT")
                .IsFixedLength(true);

            builder.Property(e => e.ShipDate)
                .HasColumnType("date")
                .HasColumnName("SHIP_DATE")
                .IsRequired(false);

            builder.Property(e => e.ShipFee)
                .HasColumnName("SHIP_FEE")
                .IsRequired(false);

            builder.Property(e => e.TotalPay)
                .HasColumnName("TOTAL_PAY")
                .IsRequired(false);

            builder.Property(e => e.CustomerTypeId)
                .HasColumnName("CUSTOMER_TYPE_ID")
                .IsRequired(false);

            builder.Property(e => e.PromotionId)
                .HasColumnName("PROMOTION_ID")
                .IsRequired(false);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_ORDER_PRODUCTS_CUSTOMERS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.User)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_ORDER_PRODUCTS_USERS")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.MailNonCus)
                .HasMaxLength(100)
                .HasColumnName("MAIL_NON_CUS");

            builder.Property(e => e.OrderProductId)
                .HasMaxLength(6)
                .HasColumnName("OrderProductId");

            builder.HasOne(d => d.Promotion)
              .WithMany(p => p.OrderProducts)
              .HasForeignKey(d => d.PromotionId)
              .HasConstraintName("FK_PromotionOrder");

        }
    }
}

