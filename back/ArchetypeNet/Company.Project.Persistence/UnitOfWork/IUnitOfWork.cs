// <summary>
// <copyright file="IUnitOfWork.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.UnitOfWork
{
    /// <summary>
    /// IUnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Method to save change.
        /// </summary>
        /// <returns>A <see cref="Task{int}"/> representing the result of the asynchronous operation.</returns>
        Task<int> SaveChangesAsync();
    }
}
