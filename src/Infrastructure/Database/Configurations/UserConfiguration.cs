using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBookManager.Domain.Users;

namespace TravelBookManager.Infrastructure.Database.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.OwnsOne(u => u.Name, nameBuilder =>
            {
                nameBuilder.Property(n => n.Text).HasColumnName("Name").IsRequired();
            });
            builder.OwnsOne(u => u.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Text).HasColumnName("Email").IsRequired();
            });
            builder.OwnsOne(u => u.Username, usernameBuilder =>
            {
                usernameBuilder.Property(un => un.Text).HasColumnName("Username").IsRequired();
            });
            builder.OwnsOne(u => u.Password, passwordBuilder =>
            {
                passwordBuilder.Property(p => p.Hash).HasColumnName("PasswordHash").IsRequired();
            });
            builder.HasMany(u => u.SavedTrips).WithMany().UsingEntity(j => j.ToTable("UserTrips"));
            builder.Navigation(u => u.SavedTrips).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}