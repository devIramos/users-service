// <summary>
// <copyright file="ExampleNotifyHandlerTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Test.Handlers
{
    using System.Threading;
    using Company.Project.Common.Notifications.Module;
    using Company.Project.Facade.Handlers.Module;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class ExampleNotifyHandlerTest.
    /// </summary>
    [TestFixture]
    public class ExampleNotifyHandlerTest
    {
        private ILogger<ExampleNotifyHandler> logger;
        private ExampleNotifyHandler exampleNotifyHandler;

        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mockLogger = new Mock<ILogger<ExampleNotifyHandler>>();
            this.logger = mockLogger.Object;
            this.exampleNotifyHandler = new ExampleNotifyHandler(this.logger);
        }

        /// <summary>
        /// ValidateConstructorInvalids.
        /// </summary>
        [Test]
        public void ValidateConstructorInvalids()
        {
            Assert.Throws<ArgumentNullException>(() => new ExampleNotifyHandler(null));
        }

        /// <summary>
        /// Method ValidateHandle.
        /// </summary>
        [Test]
        public void ValidateHandle()
        {
            var notification = new SampleNotification();
            var cancellationToken = CancellationToken.None;
            Assert.DoesNotThrowAsync(async () => await this.exampleNotifyHandler.Handle(notification, cancellationToken));
        }
    }
}
