using eBPS.Application.Interfaces;
using eBPS.Infrastructure.Services;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using eBPS.Infrastructure.Interfaces;

namespace eBPS.Infrastructure.Tests.Services
{
    [TestFixture]
    public class EmailServiceTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<ISmtpClientWrapper> _mockSmtpClient;
        private EmailService _emailService;

        [SetUp]
        public void SetUp()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockSmtpClient = new Mock<ISmtpClientWrapper>();

            // Mocking configuration values
            _mockConfiguration.Setup(c => c["EmailSettings:SmtpServer"]).Returns("smtp.gmail.com");
            _mockConfiguration.Setup(c => c["EmailSettings:SmtpPort"]).Returns("587");
            _mockConfiguration.Setup(c => c["EmailSettings:SmtpUser"]).Returns("testuser@gmail.com");
            _mockConfiguration.Setup(c => c["EmailSettings:SmtpPassword"]).Returns("password");

            // Inject dependencies into EmailService
            _emailService = new EmailService(_mockConfiguration.Object, _mockSmtpClient.Object);
        }

        [Test]
        public void SendEmail_ValidInputs_EmailSentSuccessfully()
        {
            // Arrange
            string to = "recipient@example.com";
            string subject = "Test Subject";
            string body = "This is a test email.";

            var mimeMessageCaptured = new MimeMessage();

            // Mocking SmtpClient behavior
            _mockSmtpClient
                .Setup(s => s.Connect(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<MailKit.Security.SecureSocketOptions>()))
                .Verifiable();

            _mockSmtpClient
                .Setup(s => s.Authenticate(It.IsAny<string>(), It.IsAny<string>()))
                .Verifiable();

            _mockSmtpClient
                .Setup(s => s.Send(It.IsAny<MimeMessage>()))
                .Callback<MimeMessage>(msg => mimeMessageCaptured = msg) // Capture sent email for verification
                .Verifiable();

            _mockSmtpClient
                .Setup(s => s.Disconnect(true))
                .Verifiable();

            // Act
            Assert.DoesNotThrow(() => _emailService.SendEmail(to, subject, body));

            // Assert
            Assert.That(mimeMessageCaptured, Is.Not.Null, "Email message should not be null.");
            Assert.That(mimeMessageCaptured.To.ToString(), Contains.Substring(to), "Recipient address should match.");
            Assert.That(mimeMessageCaptured.Subject, Is.EqualTo(subject), "Subject should match.");
            Assert.That(mimeMessageCaptured.TextBody, Is.EqualTo(body), "Email body should match.");

            // Verify SmtpClient calls
            _mockSmtpClient.Verify(s => s.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls), Times.Once);
            _mockSmtpClient.Verify(s => s.Authenticate("testuser@gmail.com", "password"), Times.Once);
            _mockSmtpClient.Verify(s => s.Send(It.IsAny<MimeMessage>()), Times.Once);
            _mockSmtpClient.Verify(s => s.Disconnect(true), Times.Once);
        }
    }
}
