// <summary>
// <copyright file="DependencyTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Test.Dependency
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Common = Company.Project.Common;
    using Facade = Company.Project.Facade;
    using Persistence = Company.Project.Persistence;
    using Service = Company.Project.Services;

    /// <summary>
    /// Class DependencyTest.
    /// </summary>
    [TestFixture]
    public class DependencyTest
    {
        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
        }

        /// <summary>
        /// Test for validate ValidateAddFacade.
        /// </summary>
        [Test]
        public void ValidateAddFacade()
        {
            IServiceCollection services = new Mock<IServiceCollection>().Object;
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            var response = Facade.DependencyContainer.AddFacade(services, configuration);
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Test for validate ValidateAddAppServices.
        /// </summary>
        [Test]
        public void ValidateAddAppServices()
        {
            IServiceCollection services = new Mock<IServiceCollection>().Object;
            var response = Service.DependencyContainer.AddAppServices(services);
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Test for ValidateAddAutoMapper.
        /// </summary>
        [Test]
        public void ValidateAddAutoMapper()
        {
            IServiceCollection services = new Mock<IServiceCollection>().Object;
            var response = Common.DependencyInjection.AddAutoMapper(services);
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Test for validate ValidateAddAppPersistence.
        /// </summary>
        [Test]
        public void ValidateAddAppPersistence()
        {
            IServiceCollection services = new Mock<IServiceCollection>().Object;
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            var response = Persistence.DependencyContainer.AddAppPersistence(services, configuration);
            Assert.IsNotNull(response);
        }
    }
}
