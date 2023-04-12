// <summary>
// <copyright file="UserController.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.API.Controllers
{
    /// <summary>
    /// Class ProjectController.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade projectFacade;
        private readonly IMediator mediator;
        private readonly IDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="projectFacade">Project Facade.</param>
        /// <param name="mediator">Project Mediator.</param>
        /// <param name="redis">Redis Cache.</param>
        public UserController(
            IUserFacade projectFacade,
            IMediator mediator,
            IConnectionMultiplexer redis)
        {
            this.projectFacade = projectFacade ?? throw new ArgumentNullException(nameof(projectFacade));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.database = redis?.GetDatabase() ?? throw new ArgumentNullException(nameof(redis));
        }

        /// <summary>
        /// Method to GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<CreateUserResponseDto> response;
            var redisKey = $"users";
            var result = await this.database.StringGetAsync(redisKey);

            if (!result.HasValue || result.Equals("[]"))
            {
                response = await this.projectFacade.GetAllAsync();
                await this.database.StringSetAsync(redisKey, JsonConvert.SerializeObject(response), TimeSpan.FromHours(1));
            }
            else
            {
                response = JsonConvert.DeserializeObject<IEnumerable<CreateUserResponseDto>>(result);
            }

            return this.Ok(response);
        }

        /// <summary>
        /// Method to GetByIdAsync.
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await this.projectFacade.GetByIdAsync(id);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to GetByIdAsync.
        /// </summary>
        /// <param name="obj">The Id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("filter")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery] UpdateUserRequestDto obj)
        {
            var response = await this.projectFacade.GetByIdAsync(1);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to InsertAsync.
        /// </summary>
        /// <param name="userRequest">CreateUserDto.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateUserRequestDto userRequest)
        {
            string user = "userToken";
            var response = await this.projectFacade.InsertAsync(user, userRequest);
            return this.Created($"/api/Project/{response.Id}", response);
        }

        /// <summary>
        /// Method to UpdateAsync.
        /// </summary>
        /// <param name="id">Id Proyect.</param>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateUserRequestDto request)
        {
            string user = "userToken";
            var response = await this.projectFacade.UpdateAsync(id, user, request);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to DeleteAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this.projectFacade.DeleteAsync(id);
            return this.Ok();
        }

        /// <summary>
        /// Method to InsertAsync.
        /// </summary>
        /// <param name="usersRequest">The list requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("/bulk")]
        [HttpPost]
        public async Task<IActionResult> BulkInsertAsync([FromBody] List<CreateUserRequestDto> usersRequest)
        {
            string user = "userToken";
            await this.projectFacade.BulkInsertAsync(user, usersRequest);
            return this.Ok();
        }

        /// <summary>
        /// Method to KafkaAsync.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("/kafka")]
        [HttpGet]
        public async Task<IActionResult> KafkaAsync()
        {
            await this.projectFacade.KafkaAsync();
            return this.Ok();
        }

        /// <summary>
        /// Method to MediatR.
        /// </summary>
        /// <param name="notification">Object ExapleNotification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Route("/mediatr")]
        [HttpPost]
        public IActionResult MediatR(SampleNotification notification)
        {
            _ = this.mediator.Publish(notification);
            return this.Ok(notification);
        }

        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <returns>Pong.</returns>
        [Route("/ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return this.Ok("Pong");
        }
    }
}
