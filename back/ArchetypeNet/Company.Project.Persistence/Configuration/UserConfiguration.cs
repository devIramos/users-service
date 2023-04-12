// <summary>
// <copyright file="UserConfiguration.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.Configuration
{
    /// <summary>
    /// RoleConfiguration class.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.UserCreated)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Created)
                .IsRequired();

            builder.Property(s => s.UserModified)
                .HasMaxLength(100);

            builder.Property(s => s.Active)
                .IsRequired();

            builder.HasMany(s => s.Roles)
                .WithMany(c => c.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));
        }
    }
}
