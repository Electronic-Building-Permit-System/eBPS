using eBPS.Application.Interfaces;
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

        public EmailService(IConfiguration configuration)
        {
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _smtpUser = configuration["EmailSettings:SmtpUser"];
            _smtpPassword = configuration["EmailSettings:SmtpPassword"];
        }

        public void SendEmail(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("eBPS", _smtpUser));
            email.To.Add(new MailboxAddress("Recipient Name", to));
            email.Subject = subject;
            email.Body = new TextPart("plain") { Text = body };

            using var smtp = new SmtpClient();

            try
            {
                // Connect to the Gmail SMTP server
                smtp.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);

                // Authenticate with Gmail using your credentials
                smtp.Authenticate(_smtpUser, _smtpPassword);

                // Send the email
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Disconnect from the SMTP server
                smtp.Disconnect(true);
                smtp.Dispose();
            }
        }
    }
}
