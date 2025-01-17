using MimeKit;

namespace eBPS.Infrastructure.Interfaces
{
    public interface ISmtpClientWrapper : IDisposable
    {
        void Connect(string host, int port, MailKit.Security.SecureSocketOptions options);
        void Authenticate(string userName, string password);
        void Send(MimeMessage message);
        void Disconnect(bool quit);
    }

}
