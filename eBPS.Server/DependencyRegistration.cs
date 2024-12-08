using eBPS.Application.Interfaces;
using eBPS.Application.Services;
using eBPS.Domain.Interfaces;
using eBPS.Infrastructure.DataAccess.Repositories;
using eBPS.Infrastructure.Interfaces;
using eBPS.Infrastructure.Services;

namespace eBPS.Server
{
    public static class DependencyRegistration
    {
        public static void ServiceRegistration(this IServiceCollection services)
        {
            // Register repositories from the Infrastructure layer
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            // Register services from the Application layer
            services.AddScoped<IUserService, UserService>();

            // Register any other infrastructure services (like logging, caching, etc.)
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}
