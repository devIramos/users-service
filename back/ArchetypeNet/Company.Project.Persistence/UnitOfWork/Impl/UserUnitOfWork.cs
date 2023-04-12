// <summary>
// <copyright file="UserUnitOfWork.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.UnitOfWork.Impl
{
    /// <summary>
    /// UserUnitOfWork class.
    /// </summary>
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly DatabaseContext context;
        private IUserDao userDao;
        private IRoleDao roleDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserUnitOfWork"/> class.
        /// </summary>
        /// <param name="context">DataBase Context.</param>
        public UserUnitOfWork(DatabaseContext context) => this.context = context;

        /// <inheritdoc />
        public IRoleDao Role
        {
            get
            {
                this.roleDao ??= new RoleDao(this.context);
                return this.roleDao;
            }
        }

        /// <inheritdoc />
        public IUserDao User
        {
            get
            {
                this.userDao ??= new UserDao(this.context);
                return this.userDao;
            }
        }

        /// <inheritdoc />
        public Task<int> SaveChangesAsync() => this.context.SaveChangesAsync();
    }
}
