// <summary>
// <copyright file="IUserFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Facade.Project
{
    /// <summary>
    /// Interface IProjectFacade.
    /// </summary>
    public interface IUserFacade
    {
        /// <summary>
        /// Method for GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<CreateUserResponseDto>> GetAllAsync();

        /// <summary>
        /// Method for GetByIdAsync.
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<CreateUserResponseDto> GetByIdAsync(int id);

        /// <summary>
        /// Method for InsertAsync.
        /// </summary>
        /// <param name="user">User name.</param>
        /// <param name="userRequest">The request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<CreateUserResponseDto> InsertAsync(string user, CreateUserRequestDto userRequest);

        /// <summary>
        /// Method for UpdateAsync.
        /// </summary>
        /// <param name="id">Project Id.</param>
        /// <param name="user">User name.</param>
        /// <param name="userRequest">The request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<CreateUserResponseDto> UpdateAsync(int id, string user, UpdateUserRequestDto userRequest);

        /// <summary>
        /// Method for DeleteAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Method for BulkInsertAsync.
        /// </summary>
        /// <param name="user">User name.</param>
        /// <param name="usersRequest">The list requests.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task BulkInsertAsync(string user, List<CreateUserRequestDto> usersRequest);

        /// <summary>
        /// Method for KafkaAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task KafkaAsync();
    }
}
