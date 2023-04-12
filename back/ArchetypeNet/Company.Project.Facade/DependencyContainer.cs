// <summary>
// <copyright file="DependencyContainer.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Facade
{
    /// <summary>
    /// DependencyContainer class.
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// Method that extend IServiceCollection to IoC.
        /// </summary>
        /// <param name="services">Service collection startup.</param>
        /// <param name="configuration">Configuration startup.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddFacade(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserFacade, UserFacade>();
            return services;
        }
    }
}