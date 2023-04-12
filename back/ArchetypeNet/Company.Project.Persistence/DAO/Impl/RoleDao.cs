// <summary>
// <copyright file="RoleDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.DAO.Impl
{
    /// <summary>
    /// RoleDao class.
    /// </summary>
    public class RoleDao : IRoleDao
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDao"/> class.
        /// </summary>
        /// <param name="context">DataBase Context.</param>
        public RoleDao(DatabaseContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public Task<List<RoleModel>> GetAllAsync(IEnumerable<int> roleIds) =>
            this.context.Roles.Where(role => roleIds.Contains(role.Id)).ToListAsync();
    }
}
