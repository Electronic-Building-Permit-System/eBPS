using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.Services;
using eBPS.Application.Services.Shared;
using eBPS.Infrastructure.DataAccess;
using eBPS.Infrastructure.DataAccess.Repositories;
using eBPS.Infrastructure.DataAccess.Repositories.Shared;
using eBPS.Infrastructure.Interfaces;
using eBPS.Infrastructure.Wrappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

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
            services.AddScoped<INBCClassRepository, NBCClassRepository>();
            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<ILandUseZoneRepository, LandUseZoneRepository>();
            services.AddScoped<ILandscapeTypeRepository, LandscapeTypeRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IBuildingApplicationRepository, BuildingApplicationRepository>();
            services.AddScoped<ILandUseSubZoneRepository, LandUseSubZoneRepository>();
            services.AddScoped<IHouseOwnerRepository, HouseOwnerRepository>();
            services.AddScoped<ILandInformationRepository, LandInformationRepository>();
            services.AddScoped<ICharkillaRepository, CharkillaRepository>();
            
            services.AddScoped<ILandOwnerRepository, LandOwnerRepository>();

            // Register services from the Application layer
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISmtpClientWrapper, SmtpClientWrapper>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IApplicationService, ApplicationService>();

            // Register any other infrastructure services (like logging, caching, etc.)
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IDbConnection>(provider => new SqlConnection(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
