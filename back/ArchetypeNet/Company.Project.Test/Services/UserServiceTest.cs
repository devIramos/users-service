// <summary>
// <copyright file="UserServiceTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Test.Services
{
    /// <summary>
    /// Class ProjectServiceTest.
    /// </summary>
    [TestFixture]
    public class UserServiceTest : BaseTest
    {
        private IUserService userService;
        private IUserUnitOfWork unitOfWork;
        private IKafka kafka;
        private IMapper mapper;

        private DatabaseContext context;

        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            this.mapper = mapperConfiguration.CreateMapper();

            DbConnection connection = new SqliteConnection("Data Source=TempProject;Mode=Memory;Cache=Shared");
            connection.Open();
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlite(connection).Options;

            this.context = new DatabaseContext(options);
            this.context.Database.EnsureDeleted();
            this.context.Database.EnsureCreated();

            this.context.Users.AddRange(GetAllProjectModel());
            this.context.SaveChanges();

            var mockKafka = new Mock<IKafka>();
            mockKafka.Setup(m => m.ProduceAsync(It.IsAny<object>(), It.IsAny<string>()));

            this.unitOfWork = new UserUnitOfWork(this.context);
            this.kafka = mockKafka.Object;

            this.userService = new UserService(this.mapper, this.unitOfWork, this.kafka);
        }

        /// <summary>
        /// Method Validate GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateGetAllAsync()
        {
            var response = await this.userService.GetAllAsync();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
            Assert.AreEqual(11, response.Count());
        }

        /// <summary>
        /// Method Validate GetByIdAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateGetByIdAsync()
        {
            int id = 1;
            var response = await this.userService.GetByIdAsync(id);

            Assert.IsNotNull(response);
            Assert.AreEqual(id, response.Id);
        }

        /// <summary>
        /// Method Validate InsertAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateInsertAsync()
        {
            var user = "userToken";
            var request = new CreateUserRequestDto()
            {
                Name = "User 10",
                UserName = "user10",
                Email = "user10@yopmail.com",
                Roles = new List<CreateRoleRequestDto>
                {
                    new CreateRoleRequestDto { Id = 1 },
                    new CreateRoleRequestDto { Id = 2 },
                },
            };

            var response = await this.userService.InsertAsync(user, request);

            Assert.NotNull(response.Id);
            Assert.AreEqual(request.Name, response.Name);
            Assert.AreEqual(request.UserName, response.UserName);
            Assert.AreEqual(request.Email, response.Email);
            foreach (var role in request.Roles)
            {
                Assert.DoesNotThrow(() => response.Roles.Single(r => r.Id == role.Id));
            }
        }

        /// <summary>
        /// Method Validate UpdateAsync.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestCase(1)]
        public async Task ValidateUpdateAsync(int id)
        {
            var user = "userToken";
            var request = new UpdateUserRequestDto()
            {
                Name = "Usuario Uno",
                UserName = "user1",
            };

            var before = await this.userService.GetByIdAsync(id);
            var response = await this.userService.UpdateAsync(id, user, request);

            Assert.AreEqual(request.Name, response.Name);
            Assert.AreEqual(request.UserName, response.UserName);

            Assert.AreEqual(before.Id, response.Id);
            Assert.AreEqual(before.Email, response.Email);
            foreach (var role in before.Roles)
            {
                Assert.DoesNotThrow(() => response.Roles.Single(r => r.Id == role.Id));
            }
        }

        /// <summary>
        /// Method Validate DeleteAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateDeleteAsync()
        {
            var id = 9;
            var before = await this.userService.GetByIdAsync(id);
            await this.userService.DeleteAsync(id);
            var after = await this.userService.GetByIdAsync(id);

            Assert.IsNotNull(before);
            Assert.IsNull(after);
        }

        /// <summary>
        /// Method Validate BulkInsertAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateBulkInsertAsync()
        {
            var requests = new List<CreateUserRequestDto>()
            {
                new CreateUserRequestDto() { Name = "User 11", UserName = "user11", Email = "user11@yopmail.com" },
                new CreateUserRequestDto() { Name = "User 12", UserName = "user12", Email = "user12@yopmail.com" },
                new CreateUserRequestDto() { Name = "User 13", UserName = "user13", Email = "user13@yopmail.com" },
            };

            var before = await this.userService.GetAllAsync();
            await this.userService.BulkInsertAsync("userToken", requests);
            var after = await this.userService.GetAllAsync();

            Assert.AreEqual(before.Count() + requests.Count, after.Count());
        }

        /// <summary>
        /// Method Validate KafkaAsync.
        /// </summary>
        [Test]
        public void ValidateKafkaAsync()
        {
            Assert.DoesNotThrowAsync(async () => await this.userService.KafkaAsync());
        }
    }
}
