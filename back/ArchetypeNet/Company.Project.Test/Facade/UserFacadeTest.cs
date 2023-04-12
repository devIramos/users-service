// <summary>
// <copyright file="UserFacadeTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Test.Facade
{
    using Company.Project.Services.User;

    /// <summary>
    /// Class ProjectFacadeTest.
    /// </summary>
    [TestFixture]
    public class UserFacadeTest : BaseTest
    {
        private IUserFacade projectFacade;
        private IUserService projectService;

        /// <summary>
        /// The init.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "ProjectFacadeDB")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var mockProject = new Mock<IUserService>();
            var userResponse = new CreateUserResponseDto
            {
                Name = "User 1",
                UserName = "user1",
                Email = "user1@yopmail.com",
            };
            IEnumerable<CreateUserResponseDto> listUserResponse =
                new List<CreateUserResponseDto> { userResponse };

            mockProject
                .Setup(m => m.GetAllAsync())
                .Returns(Task.FromResult(listUserResponse));

            mockProject
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(userResponse));

            mockProject
                .Setup(m => m.InsertAsync(It.IsAny<string>(), It.IsAny<CreateUserRequestDto>()))
                .Returns(Task.FromResult(userResponse));

            mockProject
                .Setup(m => m.UpdateAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<UpdateUserRequestDto>()))
                .Returns(Task.FromResult(userResponse));

            mockProject
                .Setup(m => m.DeleteAsync(It.IsAny<int>()));

            mockProject
                .Setup(m => m.BulkInsertAsync(It.IsAny<string>(), It.IsAny<List<CreateUserRequestDto>>()))
                .Returns(Task.FromResult(userResponse));

            mockProject
                .Setup(m => m.KafkaAsync())
                .Returns(Task.FromResult(true));

            this.projectService = mockProject.Object;
            this.projectFacade = new UserFacade(this.projectService);
        }

        /// <summary>
        /// ValidateConstructorInvalids.
        /// </summary>
        [Test]
        public void ValidateConstructorInvalids()
        {
            Assert.Throws<ArgumentNullException>(() => new UserFacade(null));
        }

        /// <summary>
        /// Test for validate GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Test]
        public async Task ValidateGetAllAsync()
        {
            var response = await this.projectFacade.GetAllAsync();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// Test for validate GetByIdAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Test]
        public async Task ValidateGetByIdAsync()
        {
            int id = 1;
            var response = await this.projectFacade.GetByIdAsync(id);

            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Test for validate InsertAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Test]
        public async Task ValidateInsertAsync()
        {
            var request = new CreateUserRequestDto() { Name = "User 1", UserName = "user1", Email = "user1@yopmail.com", };
            var response = await this.projectFacade.InsertAsync("userToken", request);

            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Test for validate UpdateAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Test]
        public async Task ValidateUpdateAsync()
        {
            var request = new UpdateUserRequestDto() { Name = "User 1", UserName = "user1" };
            var response = await this.projectFacade.UpdateAsync(1, "userToken", request);
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Test for validate UpdateAsync BusinessException.
        /// </summary>
        [Test]
        public void ValidateUpdateAsyncBusinessException()
        {
            var messageError = "Ha ocurrido un error.";
            var mockProject = new Mock<IUserService>();
            mockProject
                .Setup(m => m.UpdateAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<UpdateUserRequestDto>()))
                .ThrowsAsync(new BusinessException(messageError));

            var facade = new UserFacade(mockProject.Object);
            var request = new UpdateUserRequestDto() { Name = "User 1", UserName = "user1" };
            Assert.ThrowsAsync<BusinessException>(
                async () => await facade.UpdateAsync(1, "userToken", request),
                messageError);
        }

        /// <summary>
        /// Test for validate DeleteAsync.
        /// </summary>
        [Test]
        public void ValidateDelete()
        {
            var id = 1;
            Assert.DoesNotThrowAsync(async () => await this.projectFacade.DeleteAsync(id));
        }

        /// <summary>
        /// Test for validate BulkInsertAsync.
        /// </summary>
        [Test]
        public void ValidateBulkInsert()
        {
            var requests = new List<CreateUserRequestDto>()
            {
                new CreateUserRequestDto() { Name = "User 1", UserName = "user1", Email = "user1@yopmail.com", },
                new CreateUserRequestDto() { Name = "User 2", UserName = "user2", Email = "user2@yopmail.com", },
                new CreateUserRequestDto() { Name = "User 3", UserName = "user3", Email = "user3@yopmail.com", },
                new CreateUserRequestDto() { Name = "User 4", UserName = "user4", Email = "user4@yopmail.com", },
            };
            Assert.DoesNotThrowAsync(async () => await this.projectFacade.BulkInsertAsync("userToken", requests));
        }

        /// <summary>
        /// Test for validate KafkaAsync.
        /// </summary>
        [Test]
        public void ValidateKafka()
        {
            Assert.DoesNotThrowAsync(async () => await this.projectFacade.KafkaAsync());
        }
    }
}
