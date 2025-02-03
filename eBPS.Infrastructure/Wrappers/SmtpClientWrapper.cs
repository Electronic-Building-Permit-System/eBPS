using eBPS.Infrastructure.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace eBPS.Infrastructure.Wrappers
{
    public class SmtpClientWrapper : ISmtpClientWrapper
    {
        private readonly SmtpClient _smtpClient;

        public SmtpClientWrapper()
        {
            _smtpClient = new SmtpClient();
        }

        public void Connect(string host, int port, MailKit.Security.SecureSocketOptions options)
        {
            _smtpClient.Connect(host, port, options);
        }

        public void Authenticate(string userName, string password)
        {
            _smtpClient.Authenticate(userName, password);
        }

        public void Send(MimeMessage message)
        {
            _smtpClient.Send(message);
        }

        public void Disconnect(bool quit)
        {
            _smtpClient.Disconnect(quit);
        }

        public void Dispose()
        {
            _smtpClient.Dispose();
        }
    }
}
