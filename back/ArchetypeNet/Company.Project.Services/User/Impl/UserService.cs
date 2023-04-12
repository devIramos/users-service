// <summary>
// <copyright file="UserService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Services.User.Impl
{
    /// <summary>
    /// UserService class.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IKafka kafka;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        /// <param name="unitOfWork">UnitOfWork.</param>
        /// <param name="kafka">kafka.</param>
        public UserService(IMapper mapper, IUserUnitOfWork unitOfWork, IKafka kafka) =>
            (this.mapper, this.unitOfWork, this.kafka) = (mapper, unitOfWork, kafka);

        /// <inheritdoc/>
        public async Task<IEnumerable<CreateUserResponseDto>> GetAllAsync() =>
            this.mapper.Map<IEnumerable<CreateUserResponseDto>>(
                await this.unitOfWork.User.GetAllAsync());

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> GetByIdAsync(int id) =>
            this.mapper.Map<CreateUserResponseDto>(await this.unitOfWork.User.GetByIdAsync(id));

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> InsertAsync(string user, CreateUserRequestDto userRequest)
        {
            var userModel = this.mapper.Map<UserModel>(userRequest);
            userModel.UserCreated = user;
            userModel.Active = true;
            userModel.Created = DateTime.UtcNow;
            userModel.Roles = await this.unitOfWork.Role.GetAllAsync(userRequest.Roles.Select(s => s.Id));
            await this.unitOfWork.User.InsertAsync(userModel);
            await this.unitOfWork.SaveChangesAsync();
            return this.mapper.Map<CreateUserResponseDto>(userModel);
        }

        /// <inheritdoc/>
        public async Task<CreateUserResponseDto> UpdateAsync(
            int id, string user, UpdateUserRequestDto userRequest)
        {
            var userModel = await this.unitOfWork.User.GetByIdAsync(id);
            userModel.ThrowExceptionIfNull<BusinessException>($"El usuario con el id: {id} no existe.");
            userModel.Name = userRequest.Name;
            userModel.Username = userRequest.UserName;
            userModel.UserModified = user;
            userModel.Modified = DateTime.Now;
            userModel = this.unitOfWork.User.Update(userModel);
            await this.unitOfWork.SaveChangesAsync();
            return this.mapper.Map<CreateUserResponseDto>(userModel);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var modelUser = await this.unitOfWork.User.GetByIdAsync(id);
            this.unitOfWork.User.Delete(modelUser);
            await this.unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task BulkInsertAsync(string user, List<CreateUserRequestDto> usersRequest)
        {
            var usersModel = this.mapper.Map<List<UserModel>>(usersRequest);
            usersModel.ForEach(userModel =>
            {
                userModel.UserCreated = user;
                userModel.Created = DateTime.UtcNow;
            });
            await this.unitOfWork.User.BulkInsertAsync(usersModel);
        }

        /// <inheritdoc/>
        public async Task KafkaAsync()
        {
            var message = new UserMessagesDto
            {
                Message = "Example kafka",
            };
            await this.kafka.ProduceAsync(message, nameof(UserMessagesDto));
        }
    }
}
