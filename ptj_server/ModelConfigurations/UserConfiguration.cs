using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ptj_server.Models;

namespace ptj_server.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("USERS");
        
        builder.HasKey(e => e.Id).HasName("PK_USER");
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Dob)
            .HasColumnType("date")
            .HasColumnName("DOB")
            .IsRequired();

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

        builder.Property(e => e.IdRole)
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(e => e.Password)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("PASSWORD");

        builder.Property(e => e.Phone)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("PHONE")
            .IsRequired(false);

        builder.Property(e => e.Username)
            .HasMaxLength(30)
            .HasColumnName("USERNAME");

        builder.HasOne(d => d.Role)
            .WithMany(p => p.Users)
            .HasForeignKey(d => d.IdRole)
            .HasConstraintName("FK_USERS_ROLE");
    }    
}
