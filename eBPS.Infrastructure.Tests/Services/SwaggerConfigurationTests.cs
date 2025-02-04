using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using eBPS.Infrastructure.Services;
using Moq;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace eBPS.Infrastructure.Tests.Services
{
    [TestFixture]
    public class SwaggerConfigurationTests
    {
        private ServiceCollection _services;
        private Mock<IConfiguration> _mockConfiguration;

        [SetUp]
        public void SetUp()
        {
            _services = new ServiceCollection();
            _mockConfiguration = new Mock<IConfiguration>();
        }

        [Test]
        public void AddSwaggerConfig_ShouldRegisterSwaggerGenService()
        {
            // Act
            _services.AddSwaggerConfig(_mockConfiguration.Object);

            // Assert
            var serviceProvider = _services.BuildServiceProvider();
            var swaggerGenService = serviceProvider.GetService(typeof(Microsoft.Extensions.Options.IOptions<Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions>));

            Assert.That(swaggerGenService, Is.Not.Null, "SwaggerGen service should be registered.");
        }

        [Test]
        public void AddSwaggerConfig_ShouldConfigureSecurityDefinition()
        {
            // Arrange
            _services.AddSwaggerConfig(_mockConfiguration.Object);
            var serviceProvider = _services.BuildServiceProvider();
            var swaggerOptions = serviceProvider.GetService<Microsoft.Extensions.Options.IOptions<Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions>>();
            var securitySchemes = swaggerOptions.Value.SwaggerGeneratorOptions.SecuritySchemes;
            // Assert
            Assert.That(swaggerOptions, Is.Not.Null, "SwaggerGenOptions should be configured.");
            Assert.That(securitySchemes, Is.Not.Empty, "Security definitions should be configured.");
            Assert.That(securitySchemes.ContainsKey("Bearer"), Is.True, "Bearer security definition should be added.");

            var bearerScheme = securitySchemes["Bearer"];
            Assert.That(bearerScheme, Is.Not.Null, "Bearer scheme should not be null.");
            Assert.That(bearerScheme.Description, Is.EqualTo("Please enter token in the format 'Bearer {your token}'"), "Bearer scheme description is incorrect.");
            Assert.That(bearerScheme.Type, Is.EqualTo(SecuritySchemeType.ApiKey), "Bearer scheme type is not ApiKey.");
            Assert.That(bearerScheme.In, Is.EqualTo(ParameterLocation.Header), "Bearer scheme should be in header.");
        }

        [Test]
        public void AddSwaggerConfig_ShouldConfigureSecurityRequirement()
        {
            // Arrange
            _services.AddSwaggerConfig(_mockConfiguration.Object);
            var serviceProvider = _services.BuildServiceProvider();

            // Retrieve the Swagger options via IOptions
            var swaggerOptions = serviceProvider.GetService<IOptions<SwaggerGenOptions>>();

            // Assert that SwaggerGenOptions are configured
            Assert.That(swaggerOptions, Is.Not.Null, "SwaggerGenOptions should be configured.");

            // Retrieve the actual security requirements configuration
            var securityRequirements = swaggerOptions.Value.SwaggerGeneratorOptions.SecurityRequirements;

            // Assert that security requirements are configured (this should not be empty)
            Assert.That(securityRequirements, Is.Not.Empty, "Security requirements should be configured.");

            // Check the first security requirement, should reference the 'Bearer' scheme
            var securityRequirement = securityRequirements.FirstOrDefault();
            Assert.That(securityRequirement, Is.Not.Null, "Security requirement should not be null.");

            // Ensure the security requirement references the 'Bearer' scheme
            var scheme = securityRequirement.Keys.FirstOrDefault();
            Assert.That(scheme.Reference.Id, Is.EqualTo("Bearer"), "Security requirement should reference the 'Bearer' scheme.");

            // Assert that security requirement scopes are empty as expected
            Assert.That(securityRequirement[scheme], Is.Empty, "Security requirement scopes should be empty.");
        }

    }
}
