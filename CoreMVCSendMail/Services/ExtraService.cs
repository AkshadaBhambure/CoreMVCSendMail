using CoreMVCSendMail.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CoreMVCSendMail.Services
{
    public class ExtraService : IExtraService
    {
        EmailSettings _settings;
        public ExtraService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public void SendEmail(EmailModel model)
        {

            MailboxAddress fromMail = new MailboxAddress(_settings.UserName, _settings.EmailAddress);
            MailboxAddress toEmail = new MailboxAddress(model.UserName, model.EmailAddress);
            MimeMessage message = new MimeMessage();
            message.From.Add(fromMail);
            message.To.Add(toEmail);
            message.Subject = model.Subject;
            BodyBuilder body = new BodyBuilder();
            body.HtmlBody = model.Message;
            message.Body = body.ToMessageBody();
            SmtpClient smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, _settings.UseSSL);
            smtp.Authenticate(_settings.EmailAddress,_settings.Password);
            smtp.Send(message);
            smtp.Disconnect(true);
            smtp.Dispose();

        }
    }
}
