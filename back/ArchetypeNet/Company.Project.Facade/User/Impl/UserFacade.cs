// <summary>
// <copyright file="UserFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Facade.Project.Impl
{
    using Company.Project.Services.User;

    /// <summary>
    /// Class ProjectFacade.
    /// </summary>
    public class UserFacade : IUserFacade
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFacade"/> class.
        /// </summary>
        /// <param name="userService">Interface UserService.</param>
        public UserFacade(IUserService userService) =>
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));

        /// <inheritdoc/>
        public async Task<IEnumerable<CreateUserResponseDto>> GetAllAsync() =>
            await this.userService.GetAllAsync();

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> GetByIdAsync(int id) =>
            await this.userService.GetByIdAsync(id);

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> InsertAsync(string user, CreateUserRequestDto userRequest) =>
            await this.userService.InsertAsync(user, userRequest);

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> UpdateAsync(
            int id, string user, UpdateUserRequestDto userRequest) =>
            await this.userService.UpdateAsync(id, user, userRequest);

        /// <inheritdoc/>
        public async Task DeleteAsync(int id) =>
            await this.userService.DeleteAsync(id);

        /// <inheritdoc/>
        public async Task BulkInsertAsync(string user, List<CreateUserRequestDto> usersRequest) =>
            await this.userService.BulkInsertAsync(user, usersRequest);

        /// <inheritdoc/>
        public async Task KafkaAsync() =>
            await this.userService.KafkaAsync();
    }
}
