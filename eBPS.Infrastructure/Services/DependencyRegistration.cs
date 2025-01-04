using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.Services;
using eBPS.Infrastructure.DataAccess;
using eBPS.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eBPS.Infrastructure.Services
{
    public static class DependencyRegistration
    {
        public static void ServiceRegistration(this IServiceCollection services, string connectionString)
        {
            // Register repositories from the Infrastructure layer
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IBuildingPurposeRepository, BuildingPurposeRepository>();
            services.AddScoped<IStructureTypeRepository, StructureTypeRepository>();

            // Register services from the Application layer
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IApplicationService, ApplicationService>();

            // Register any other infrastructure services (like logging, caching, etc.)
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUnitOfWork>(_ => new UnitOfWork(connectionString));
        }
    }
}
