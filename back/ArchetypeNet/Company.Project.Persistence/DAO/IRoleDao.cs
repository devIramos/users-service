// <summary>
// <copyright file="IRoleDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.DAO
{
    /// <summary>
    /// Interface IRoleDao.
    /// </summary>
    public interface IRoleDao
    {
        /// <summary>
        /// Method to get roles by a collection of role id.
        /// </summary>
        /// <param name="roleIds">Collection of Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<RoleModel>> GetAllAsync(IEnumerable<int> roleIds);
    }
}
