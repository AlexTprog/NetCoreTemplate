using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreTemplate.Domain.Users;

namespace NetCoreTemplate.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> builder
        )
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
               .HasMaxLength(200)
               .HasConversion(nombre => nombre!.Value, value => new Name(value));

        builder.Property(user => user.LastName)
               .HasMaxLength(200)
               .HasConversion(apellido => apellido!.Value, value => new LastName(value));

        builder.Property(user => user.Email)
               .HasMaxLength(400)
               .HasConversion(email => email!.Value, value => new Email(value));

        builder.HasIndex(user => user.Email)
               .IsUnique();
    }
}