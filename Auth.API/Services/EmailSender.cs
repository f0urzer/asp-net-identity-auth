using Auth.API.Configs;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Auth.API.Services
{
    public class EmailSender(ILogger<EmailSender> logger, IOptions<SmtpConfig> options) : IEmailSender
    {
        private readonly SmtpConfig _smtp = options.Value;

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient
            {
                Host = _smtp.Host,
                Port = _smtp.Port,
                EnableSsl = _smtp.IsSSL,
                Credentials = new NetworkCredential(_smtp.Username, _smtp.Password)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtp.From),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                logger.LogError($"Email sending failed: {ex.Message}");
            }
        }
    }

}
