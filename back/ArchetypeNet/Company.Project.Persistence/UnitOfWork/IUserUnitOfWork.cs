// <summary>
// <copyright file="IUserUnitOfWork.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.UnitOfWork
{
    /// <summary>
    /// IUserUnitOfWork interface.
    /// </summary>
    public interface IUserUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets User.
        /// </summary>
        /// <value>
        /// IUserDao User.
        /// </value>
        IUserDao User { get; }

        /// <summary>
        /// Gets Role.
        /// </summary>
        /// <value>
        /// IRoleDao Role.
        /// </value>
        IRoleDao Role { get; }
    }
}
