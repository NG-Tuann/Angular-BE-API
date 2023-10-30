using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations;

public class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("ROLES");
        
        builder.HasKey(e => e.Id).HasName("PK_ROLE");
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        
        builder.Property(e => e.Name)
            .HasMaxLength(30)
            .HasColumnName("NAME");
    }
}