using Moq;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.Interfaces;
using eBPS.Application.Services;
using eBPS.Infrastructure.DataAccess.Repositories;
using eBPS.Infrastructure.Services;
using eBPS.Infrastructure.DataAccess;
using System;
using Microsoft.OpenApi.Models;

namespace eBPS.Infrastructure.Tests.Services
{
    [TestFixture]
    public class DependencyRegistrationTests
    {
        private IServiceCollection _services;
        private string _connectionString = "TestConnectionString";

        [SetUp]
        public void SetUp()
        {
            // Initialize the service collection for each test
            _services = new ServiceCollection();
        }

        [Test]
        public void ServiceRegistration_ShouldRegisterRequiredServices()
        {
            // Act
            _services.ServiceRegistration(_connectionString);

            // Assert all services are registered
            AssertRegisteredService<IUserRepository>();
            AssertRegisteredService<IRoleRepository>();
            AssertRegisteredService<IOrganizationRepository>();
            AssertRegisteredService<IBuildingPurposeRepository>();
            AssertRegisteredService<IStructureTypeRepository>();
            AssertRegisteredService<INBCClassRepository>();
            AssertRegisteredService<IWardRepository>();
            AssertRegisteredService<ILandUseZoneRepository>();
            AssertRegisteredService<ILandscapeTypeRepository>();
            AssertRegisteredService<ITransactionTypeRepository>();
            AssertRegisteredService<IIssueDistrictRepository>();
            AssertRegisteredService<IBuildingApplicationRepository>();
            AssertRegisteredService<ILandUseSubZoneRepository>();
            AssertRegisteredService<IHouseOwnerRepository>();
            AssertRegisteredService<IUserService>();
            AssertRegisteredService<IOrganizationService>();
            AssertRegisteredService<IRoleService>();
            AssertRegisteredService<IEmailService>();
            AssertRegisteredService<IApplicationService>();
            AssertRegisteredService<IJwtTokenGenerator>();
            AssertRegisteredService<IPasswordHasher>();
            AssertRegisteredService<IUnitOfWork>();
        }

        [Test]
        public void ServiceRegistration_ShouldRegisterServicesWithCorrectLifetime()
        {
            // Act
            _services.ServiceRegistration(_connectionString);

            // Assert that services are registered as Scoped
            AssertThatServiceHasCorrectLifetime<IUserRepository>();
            AssertThatServiceHasCorrectLifetime<IRoleRepository>();
            AssertThatServiceHasCorrectLifetime<IOrganizationRepository>();
            AssertThatServiceHasCorrectLifetime<IBuildingPurposeRepository>();
            AssertThatServiceHasCorrectLifetime<IStructureTypeRepository>();
            AssertThatServiceHasCorrectLifetime<INBCClassRepository>();
            AssertThatServiceHasCorrectLifetime<IWardRepository>();
            AssertThatServiceHasCorrectLifetime<ILandUseZoneRepository>();
            AssertThatServiceHasCorrectLifetime<ILandscapeTypeRepository>();
            AssertThatServiceHasCorrectLifetime<ITransactionTypeRepository>();
            AssertThatServiceHasCorrectLifetime<IIssueDistrictRepository>();
            AssertThatServiceHasCorrectLifetime<IBuildingApplicationRepository>();
            AssertThatServiceHasCorrectLifetime<ILandUseSubZoneRepository>();
            AssertThatServiceHasCorrectLifetime<IHouseOwnerRepository>();
            AssertThatServiceHasCorrectLifetime<IUserService>();
            AssertThatServiceHasCorrectLifetime<IOrganizationService>();
            AssertThatServiceHasCorrectLifetime<IRoleService>();
            AssertThatServiceHasCorrectLifetime<IEmailService>();
            AssertThatServiceHasCorrectLifetime<IApplicationService>();
            AssertThatServiceHasCorrectLifetime<IJwtTokenGenerator>();
            AssertThatServiceHasCorrectLifetime<IPasswordHasher>();
            AssertThatServiceHasCorrectLifetime<IUnitOfWork>();
        }

        private void AssertRegisteredService<TService>()
        {
            var serviceDescriptor = _services.SingleOrDefault(sd => sd.ServiceType == typeof(TService));
            Assert.That(serviceDescriptor, Is.Not.Null, $"{typeof(TService).Name} was not registered.");
        }

        private void AssertThatServiceHasCorrectLifetime<TService>()
        {
            var serviceDescriptor = _services.SingleOrDefault(sd => sd.ServiceType == typeof(TService));
            Assert.That(serviceDescriptor, Is.Not.Null, $"{typeof(TService).Name} was not registered.");
            Assert.That(serviceDescriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped), $"{typeof(TService).Name} is not registered as Scoped.");
        }
    }
}
