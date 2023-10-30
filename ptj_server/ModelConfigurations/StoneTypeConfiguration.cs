using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations
{
	public class StoneTypeConfiguration : IEntityTypeConfiguration<StoneType>
    {
        public void Configure(EntityTypeBuilder<StoneType> builder)
        {
            builder.ToTable("STONE_TYPES");

            builder.HasKey(e => e.Id).HasName("PK_STONE_TYPE");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
        }
    }
}

