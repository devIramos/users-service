// <summary>
// <copyright file="DependencyInjection.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.Common
{
    /// <summary>
    /// DependencyInjection static.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add configuration Auto Mapper.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>Interface Service Collection.</returns>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            return services;
        }
    }
}
