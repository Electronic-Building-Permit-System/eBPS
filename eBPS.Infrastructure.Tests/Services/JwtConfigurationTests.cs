using eBPS.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.Text;

namespace eBPS.Infrastructure.Tests.Services
{
    [TestFixture]
    public class JwtConfigurationTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IConfigurationSection> _mockJwtSettingsSection;
        private IServiceCollection _services;

        [SetUp]
        public void SetUp()
        {
            // Initialize mocks and service collection
            _mockConfiguration = new Mock<IConfiguration>();
            _mockJwtSettingsSection = new Mock<IConfigurationSection>();
            _services = new ServiceCollection();

            // Mock JwtSettings section in IConfiguration
            _mockConfiguration.Setup(c => c.GetSection("JwtSettings")).Returns(_mockJwtSettingsSection.Object);
            _mockJwtSettingsSection.Setup(s => s["Issuer"]).Returns("TestIssuer");
            _mockJwtSettingsSection.Setup(s => s["Audience"]).Returns("TestAudience");
            _mockJwtSettingsSection.Setup(s => s["SecretKey"]).Returns("TestSecretKey12345"); // Ensure it's long enough for symmetric encryption
        }

        [Test]
        public void AddJwtConfig_ShouldConfigureJwtAuthentication()
        {
            // Act
            JwtConfiguration.AddJwtConfig(_services, _mockConfiguration.Object);

            // Assert
            var serviceProvider = _services.BuildServiceProvider();
            var authenticationBuilder = serviceProvider.GetService<IAuthenticationSchemeProvider>();

            Assert.That(authenticationBuilder, Is.Not.Null, "Authentication has not been configured.");

            var jwtBearerOptions = serviceProvider.GetRequiredService<IOptionsMonitor<JwtBearerOptions>>().Get(JwtBearerDefaults.AuthenticationScheme);

            // Validate JWT settings
            Assert.That(jwtBearerOptions.TokenValidationParameters.ValidateIssuer, Is.True);
            Assert.That(jwtBearerOptions.TokenValidationParameters.ValidateAudience, Is.True);
            Assert.That(jwtBearerOptions.TokenValidationParameters.ValidateLifetime, Is.True);
            Assert.That(jwtBearerOptions.TokenValidationParameters.ValidateIssuerSigningKey, Is.True);

            Assert.That(jwtBearerOptions.TokenValidationParameters.ValidIssuer, Is.EqualTo("TestIssuer"));
            Assert.That(jwtBearerOptions.TokenValidationParameters.ValidAudience, Is.EqualTo("TestAudience"));
            Assert.That(
                jwtBearerOptions.TokenValidationParameters.IssuerSigningKey,
                Is.InstanceOf<SymmetricSecurityKey>()
            );

            var symmetricKey = (SymmetricSecurityKey)jwtBearerOptions.TokenValidationParameters.IssuerSigningKey;
            Assert.That(Encoding.UTF8.GetString(symmetricKey.Key), Is.EqualTo("TestSecretKey12345"));
        }
    }
}

