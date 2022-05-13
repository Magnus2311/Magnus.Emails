using Magnus.Emails.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Magnus.Emails.Services
{
    public class GmailSmtpEmailsService : IEmailsService
    {
        private readonly SmtpClient _smtpClient;
        private readonly ITemplate _template;

        public GmailSmtpEmailsService(ITemplate template)
        {
            _template = template;
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_template.Credentials.Username, _template.Credentials.Password),
                EnableSsl = true,
            };
        }

        public async Task ReSendRegistrationEmail(string url, string email, string token)
        {
            var message = new MailMessage(_template.Credentials.Username, email, $"New confirmation email from {_template.SiteName}", $"{url}/auth/confirmEmail/{email}&{token}")
            {
                IsBodyHtml = true
            };
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendRegistrationEmail(string url, string email, string token, string template)
        {
            var message = new MailMessage(_template.Credentials.Username, email)
            {
                Subject = $"Welcome to {_template.SiteName}"
            };
            message.IsBodyHtml = true;
            message.AlternateViews.Add(GetEmbeddedImage($"{_template.LogoPath}", template, token));

            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendResetPasswordEmail(string url, string email, string token, string template)
        {
            var message = new MailMessage(_template.Credentials.Username, email)
            {
                Subject = $"Reset password for {_template.SiteName}"
            };
            message.IsBodyHtml = true;
            message.AlternateViews.Add(GetEmbeddedImage($"{_template.LogoPath}", template, token));

            await _smtpClient.SendMailAsync(message);
        }

        private static AlternateView GetEmbeddedImage(string filePath, string template, string token)
        {
            LinkedResource res = new(filePath)
            {
                ContentType = new ContentType()
                {
                    MediaType = "image/png",
                    Name = filePath.Split('/').LastOrDefault()
                },
                ContentId = Guid.NewGuid().ToString()
            };
            string htmlBody = string.Format(template, res.ContentId, token);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
