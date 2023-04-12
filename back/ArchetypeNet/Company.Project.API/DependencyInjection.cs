// <summary>
// <copyright file="DependencyInjection.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Company.Project.API
{
    using Company.Project.Services;

    /// <summary>
    /// DependencyInjection static.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Config application.
        /// </summary>
        /// <param name="webApplication">WebApplicationBuilder.</param>
        /// <returns>WebApplication.</returns>
        public static WebApplication AppConfiguration(this WebApplicationBuilder webApplication)
        {
            webApplication.AddPlaceholderResolver();

            webApplication.Host.UseSerilog();

            // Add services to the container.
            webApplication.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomActionFilterAttribute>();
                options.Filters.Add<CustomExceptionFilterAttribute>();
            });

            // Add services to App
            webApplication.Services.RegisterServices();
            webApplication.Services.AddAppPersistence(webApplication.Configuration);
            webApplication.Services.AddAppServices();
            webApplication.Services.AddAutoMapper();

            // Pattern Mediator
            webApplication.Services.AddMediatR(typeof(ExampleNotifyHandler));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplication.Services.AddEndpointsApiExplorer();
            webApplication.Services.AddSwaggerGen();

            webApplication.Services.AddKafka(webApplication.Configuration, Log.Logger);
            webApplication.Services.AddHostedService<SampleBackground>();

            webApplication.Services.AddApplicationInsightsTelemetry();

            // Redis
            try
            {
                var configuration = ConfigurationOptions.Parse(webApplication.Configuration["redis:hostname"], true);
                configuration.ResolveDns = true;
                webApplication.Services.AddSingleton<IConnectionMultiplexer>(cm => ConnectionMultiplexer.Connect(configuration));
            }
            catch (Exception)
            {
                Log.Logger.Error("No se encontro Redis");
            }

            return webApplication.Build();
        }

        /// <summary>
        /// Use application.
        /// </summary>
        /// <param name="app">WebApplicationBuilder.</param>
        /// <returns>WebApplication.</returns>
        public static WebApplication UseApplication(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }

        /// <summary>
        /// Method to register Services.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>Interface Service Collection.</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserFacade, UserFacade>();
            return services;
        }
    }
}
