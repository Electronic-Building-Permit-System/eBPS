using eBPS.Application.DTOs;
using eBPS.Application.Interfaces;
using eBPS.Application.Services;
using eBPS.Server.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace eBPS.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private Mock<IUserService> _mockUserService;
        private Mock<IEmailService> _mockEmailService;
        private AccountController _accountController;

        [SetUp]
        public void SetUp()
        {
            _mockUserService = new Mock<IUserService>();
            _mockEmailService = new Mock<IEmailService>();
            _accountController = new AccountController(_mockUserService.Object, _mockEmailService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _accountController?.Dispose(); // Dispose of the controller if it implements IDisposable
        }

        [Test]
        public async Task Register_ShouldReturnCreated_WhenUserIsRegisteredSuccessfully()
        {
            // Arrange
            var userDto = new RegisterUserDTO { Username = "testuser", Password = "password" };
            _mockUserService.Setup(service => service.RegisterUser(userDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _accountController.Register(userDto);

            // Assert
            var createdResult = result as CreatedResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
        }

        [Test]
        public async Task Register_ShouldReturnBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var userDto = new RegisterUserDTO { Username = "testuser", Password = "password" };
            _mockUserService.Setup(service => service.RegisterUser(userDto)).Throws(new Exception("Registration failed"));

            // Act
            var result = await _accountController.Register(userDto);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public async Task Login_ShouldReturnOk_WhenLoginIsSuccessful()
        {
            // Arrange
            var loginDto = new LoginUserDTO { Username = "testuser", Password = "password" };
            _mockUserService.Setup(service => service.LoginUser(loginDto)).ReturnsAsync("test-token");

            // Act
            var result = await _accountController.Login(loginDto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task Login_ShouldReturnBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var loginDto = new LoginUserDTO { Username = "testuser", Password = "password" };
            _mockUserService.Setup(service => service.LoginUser(loginDto)).Throws(new Exception("Invalid credentials"));

            // Act
            var result = await _accountController.Login(loginDto);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void ForgetPassword_ShouldReturnOk_WhenEmailIsSentSuccessfully()
        {
            // Arrange
            var forgetPasswordDto = new ForgetPasswordDTO { To = "test@example.com", Subject = "Reset Password", Body = "Test body" };

            // Act
            var result = _accountController.ForgetPassword(forgetPasswordDto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ForgetPassword_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var forgetPasswordDto = new ForgetPasswordDTO { To = "test@example.com", Subject = "Reset Password", Body = "Test body" };
            _mockEmailService.Setup(service => service.SendEmail(forgetPasswordDto.To, forgetPasswordDto.Subject, forgetPasswordDto.Body))
                .Throws(new Exception("Email sending failed"));

            // Act
            var result = _accountController.ForgetPassword(forgetPasswordDto);

            // Assert
            var internalServerErrorResult = result as ObjectResult;
            Assert.That(internalServerErrorResult, Is.Not.Null);
            Assert.That(internalServerErrorResult.StatusCode, Is.EqualTo(500));
        }
    }
}
