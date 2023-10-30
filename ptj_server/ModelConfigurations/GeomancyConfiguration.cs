using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations;

public class GeomancyConfiguration:IEntityTypeConfiguration<Geomancy>
{
    public void Configure(EntityTypeBuilder<Geomancy> builder)
    {
        builder.ToTable("GEOMANCIES");
        
        builder.HasKey(e => e.Id)
            .HasName("PK_GEOMANCY");
        
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Description)
            .HasColumnName("DESCRIPTION")
            .IsRequired(false);
        
        builder.Property(e => e.Name)
            .HasMaxLength(30)
            .HasColumnName("NAME");
    }
}