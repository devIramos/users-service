// <summary>
// <copyright file="RoleConfiguration.cs" company="Axity">
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
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.ToTable("Roles");

            builder.Property(s => s.Name)
                .HasMaxLength(100)
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

            builder.HasData(
                new RoleModel { Id = 1, Name = "Administrador", Created = DateTime.Now, UserCreated = "system", Active = true },
                new RoleModel { Id = 2, Name = "Rol2", Created = DateTime.Now, UserCreated = "system", Active = true },
                new RoleModel { Id = 3, Name = "Rol3", Created = DateTime.Now, UserCreated = "system", Active = true },
                new RoleModel { Id = 4, Name = "Rol4", Created = DateTime.Now, UserCreated = "system", Active = true });
        }
    }
}
