using System.Net.Mail;
using System.Net;
using Services.Interfaces;
using Core.Options;
using Microsoft.Extensions.Options;

namespace Services.Implementations
{
    public class SmtpService : ISmtpService
    {
        private EmailConfigurationOptions _emailOptions;

        public SmtpService(IOptions<EmailConfigurationOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public void SendEmail(string mailTo, string subject, string body)
        {
            using (var mailMessage = new MailMessage())
            using (var client = new SmtpClient(_emailOptions.SmtpServer, _emailOptions.SmtpPort))
            {
                // configure the client and send the message
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailOptions.SmtpUser, _emailOptions.SmtpPassword);
                client.EnableSsl = _emailOptions.Ssl;

                // configure the mail message
                mailMessage.From = new MailAddress(_emailOptions.From);
                mailMessage.To.Insert(0, new MailAddress(mailTo));
                mailMessage.Subject = subject;

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = body;
                client.Send(mailMessage);
            }
        }
    }
}
