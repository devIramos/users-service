// <summary>
// <copyright file="ExampleNotifyHandler.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Facade.Handlers.Module
{
    /// <summary>
    /// ExampleNotifyHandler class.
    /// </summary>
    public class ExampleNotifyHandler : INotificationHandler<SampleNotification>
    {
        private readonly ILogger<ExampleNotifyHandler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleNotifyHandler"/> class.
        /// </summary>
        /// <param name="logger">Logger</param>
        public ExampleNotifyHandler(ILogger<ExampleNotifyHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task Handle(SampleNotification notification, CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            this.logger.LogInformation("Notificación MediatR para: {Name}", notification.Name);
        }
    }
}
