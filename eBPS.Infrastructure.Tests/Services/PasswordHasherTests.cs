using eBPS.Infrastructure.Services;

namespace eBPS.Infrastructure.Tests.Services
{
    [TestFixture]
    public class PasswordHasherTests
    {
        private PasswordHasher _passwordHasher;

        [SetUp]
        public void SetUp()
        {
            // Initialize PasswordHasher instance
            _passwordHasher = new PasswordHasher();
        }

        [Test]
        public void HashPassword_ShouldReturnHashedPassword()
        {
            // Arrange
            string password = "MySecurePassword123";

            // Act
            string hashedPassword = _passwordHasher.HashPassword(password);

            // Assert
            Assert.That(hashedPassword, Is.Not.EqualTo(password), "Hashed password should not be the same as the original password.");
            Assert.That(BCrypt.Net.BCrypt.Verify(password, hashedPassword), Is.True, "Hashed password should verify correctly.");
        }

        [Test]
        public void VerifyPassword_ShouldReturnTrue_ForValidPassword()
        {
            // Arrange
            string password = "MySecurePassword123";
            string hashedPassword = _passwordHasher.HashPassword(password);

            // Act
            bool isVerified = _passwordHasher.VerifyPassword(password, hashedPassword);

            // Assert
            Assert.That(isVerified, Is.True, "Password should be verified correctly.");
        }

        [Test]
        public void VerifyPassword_ShouldReturnFalse_ForInvalidPassword()
        {
            // Arrange
            string password = "MySecurePassword123";
            string hashedPassword = _passwordHasher.HashPassword(password);

            // Act
            bool isVerified = _passwordHasher.VerifyPassword("IncorrectPassword", hashedPassword);

            // Assert
            Assert.That(isVerified, Is.False, "Incorrect password should not be verified.");
        }
    }
}
