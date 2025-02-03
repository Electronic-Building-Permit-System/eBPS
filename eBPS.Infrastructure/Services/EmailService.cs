using eBPS.Application.Interfaces;
using eBPS.Infrastructure.Interfaces;
using eBPS.Infrastructure.Wrappers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace eBPS.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPassword;
        private readonly ISmtpClientWrapper _smtpClientWrapper;

        public EmailService(IConfiguration configuration, ISmtpClientWrapper smtpClientWrapper)
        {
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _smtpUser = configuration["EmailSettings:SmtpUser"];
            _smtpPassword = configuration["EmailSettings:SmtpPassword"];
            _smtpClientWrapper = smtpClientWrapper;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("eBPS", _smtpUser));
            email.To.Add(new MailboxAddress("Recipient Name", to));
            email.Subject = subject;
            email.Body = new TextPart("plain") { Text = body };

            try
            {
                // Connect to the Gmail SMTP server
                _smtpClientWrapper.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                // Authenticate with Gmail using your credentials
                _smtpClientWrapper.Authenticate(_smtpUser, _smtpPassword);
                // Send the email
                _smtpClientWrapper.Send(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Disconnect from the SMTP server
                _smtpClientWrapper.Disconnect(true);
                _smtpClientWrapper.Dispose();
            }
        }
    }
}
