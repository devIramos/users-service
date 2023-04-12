// <summary>
// <copyright file="IUserDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Persistence.DAO
{
    /// <summary>
    /// Interface IUserDao.
    /// </summary>
    public interface IUserDao : IUnitOfWork
    {
        /// <summary>
        /// Method for GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<UserModel>> GetAllAsync();

        /// <summary>
        /// Method for GetByIdAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        ValueTask<UserModel> GetByIdAsync(int id);

        /// <summary>
        /// Method for InsertAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task InsertAsync(UserModel model);

        /// <summary>
        /// Method for UpdateAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="UserModel"/> representing the result of the operation.</returns>
        UserModel Update(UserModel model);

        /// <summary>
        /// Method for DeleteAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(UserModel model);

        /// <summary>
        /// Method for BulkInsertAsync.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task BulkInsertAsync(List<UserModel> models);
    }
}
