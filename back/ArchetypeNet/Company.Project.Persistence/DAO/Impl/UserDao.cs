// <summary>
// <copyright file="UserDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.DAO.Impl
{
    /// <summary>
    /// Class ProjectDao.
    /// </summary>
    public class UserDao : IUserDao
    {
        private const int BulkValue = 1000;
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDao"/> class.
        /// </summary>
        /// <param name="context">DataBase Context.</param>
        public UserDao(DatabaseContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserModel>> GetAllAsync()
            => await this.context.Users.ToListAsync();

        /// <inheritdoc/>
        public ValueTask<UserModel> GetByIdAsync(int id) =>
            this.context.Users.FindAsync(id);

        /// <inheritdoc/>
        public async Task InsertAsync(UserModel model)
        {
            await this.context.AddAsync(model);
            await this.context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public UserModel Update(UserModel model) =>
            this.context.Update(model).Entity;

        /// <inheritdoc/>
        public void Delete(UserModel model)
        {
            this.context.Remove(model);
        }

        /// <inheritdoc/>
        public async Task BulkInsertAsync(List<UserModel> models) =>
            await this.context.BulkInsertAsync(
                models, new BulkConfig { BatchSize = BulkValue });

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync() => await this.context.SaveChangesAsync();
    }
}
