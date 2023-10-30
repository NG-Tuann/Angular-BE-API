using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMERS");

            builder.HasKey(e => e.Id)
                 .HasName("PK_CUSTOMER");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Address)
                .HasMaxLength(80)
                .HasColumnName("ADDRESS")
                .IsRequired(false);

            builder.Property(e => e.CustomerTypeId)
                .HasColumnName("CUSTOMER_TYPE_ID")
                .IsRequired(false);

            builder.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB")
                .IsRequired(false);

            builder.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("FULLNAME")
                .IsRequired(false);

            builder.Property(e => e.IdCard)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ID_CARD")
                .IsFixedLength(true)
                .IsRequired(false);

            builder.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");

            builder.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PHONE")
                .IsFixedLength(true)
                .IsRequired(false);

            builder.Property(e => e.Avatar)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("AVATAR")
                .IsFixedLength(true)
                .IsRequired(false);

            builder.Property(e => e.ScorePay)
                .HasColumnName("SCORE_PAY")
                .IsRequired(false); 

            builder.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME")
                .IsRequired(false);

            builder.HasOne(d => d.CustomerType)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .HasConstraintName("FK_CUSTOMER_TYPE");
        }
    }
}

