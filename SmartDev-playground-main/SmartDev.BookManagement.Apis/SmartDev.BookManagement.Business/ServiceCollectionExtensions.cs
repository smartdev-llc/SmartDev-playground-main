using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDev.BookManagement.DB;

namespace SmartDev.BookManagement.Business
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterComponentServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSettings = configuration.GetSection(nameof(DBSettings)).Get<DBSettings>();
            services.AddSingleton(typeof(DBSettings), dbSettings);

            services.AddDbContext<BookMngDbContext>(x => x.UseSqlServer(dbSettings.ConnectionString), ServiceLifetime.Transient);

            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IBookService, BookService>()
                .AddTransient<IUserBookRelationRepository, UserBookRelationRepository>()
                .AddTransient<IUserBookRelationService, UserBookRelationService>()
                ;

            return services;
        }
    }
}
