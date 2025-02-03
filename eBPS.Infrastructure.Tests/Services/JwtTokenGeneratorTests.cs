using eBPS.Domain.Entities.Shared;
using eBPS.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace eBPS.Infrastructure.Tests.Services
{
    [TestFixture]
    public class JwtTokenGeneratorTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IConfigurationSection> _mockJwtSettingsSection;
        private JwtTokenGenerator _jwtTokenGenerator;

        [SetUp]
        public void SetUp()
        {
            // Mock configuration
            _mockConfiguration = new Mock<IConfiguration>();
            _mockJwtSettingsSection = new Mock<IConfigurationSection>();

            _mockConfiguration.Setup(c => c.GetSection("JwtSettings")).Returns(_mockJwtSettingsSection.Object);
            _mockJwtSettingsSection.Setup(s => s["SecretKey"]).Returns("SuperSecretKey123456789Test987654321");
            _mockJwtSettingsSection.Setup(s => s["Issuer"]).Returns("TestIssuer");
            _mockJwtSettingsSection.Setup(s => s["Audience"]).Returns("TestAudience");
            _mockJwtSettingsSection.Setup(s => s["ExpiresInMinutes"]).Returns("60");

            // Initialize JwtTokenGenerator
            _jwtTokenGenerator = new JwtTokenGenerator(_mockConfiguration.Object);
        }

        [Test]
        public void GenerateJwtToken_ShouldReturnValidJwtToken()
        {
            // Arrange
            var user = new Users
            {
                Id = 1,
                Username = "TestUser"
            };

            // Act
            var token = _jwtTokenGenerator.GenerateJwtToken(user);

            // Assert
            Assert.That(token, Is.Not.Null.And.Not.Empty, "Token should not be null or empty.");

            // Decode the token to validate its claims
            var handler = new JwtSecurityTokenHandler();
            Assert.That(handler.CanReadToken(token), Is.True, "The generated token should be readable.");

            var jwtToken = handler.ReadJwtToken(token);
            Assert.That(jwtToken, Is.Not.Null, "The generated token should be a valid JWT.");

            // Validate claims
            var usernameClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
            Assert.That(usernameClaim, Is.EqualTo("TestUser"), "The 'sub' claim should match the user's username.");

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            Assert.That(userIdClaim, Is.EqualTo("1"), "The 'userId' claim should match the user's ID.");

            var issuer = jwtToken.Issuer;
            Assert.That(issuer, Is.EqualTo("TestIssuer"), "The issuer should match the configured value.");

            var audience = jwtToken.Audiences.FirstOrDefault();
            Assert.That(audience, Is.EqualTo("TestAudience"), "The audience should match the configured value.");

            var expiration = jwtToken.ValidTo;
            Assert.That(expiration, Is.GreaterThan(DateTime.UtcNow), "The token should not be expired.");
        }
    }
}
