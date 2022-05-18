using Magnus.Emails.Interfaces;
using Magnus.Emails.Pages;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Magnus.Emails.Services
{
    public class GmailSmtpEmailsService : IEmailsService
    {
        private readonly SmtpClient _smtpClient;
        private readonly ITemplate _template;
        private readonly IViewRenderService _viewRenderService;

        public GmailSmtpEmailsService(ITemplate template, IViewRenderService viewRenderService)
        {
            _template = template;
            _viewRenderService = viewRenderService;
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

        public async Task SendEmail()
        {
            var message = new MailMessage(_template.Credentials.Username, _template.Receiver!)
            {
                Subject = _template.Subject
            };
            message.IsBodyHtml = true;
            message.AlternateViews.Add(await GetEmbeddedImage());

            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendResetPasswordEmail(string url, string email, string token, string template)
        {
            var message = new MailMessage(_template.Credentials.Username, email)
            {
                Subject = $"Reset password for {_template.SiteName}"
            };
            message.IsBodyHtml = true;
            message.AlternateViews.Add(await GetEmbeddedImage());

            await _smtpClient.SendMailAsync(message);
        }

        private async Task<AlternateView> GetEmbeddedImage()
        {
            LinkedResource res = new LinkedResource(_template.LogoPath ?? "")
            {
                ContentId = Guid.NewGuid().ToString()
            };
            res.ContentType = new ContentType()
            {
                MediaType = "image/png",
                Name = "logo_transparent.png",
            };
            var htmlBody = await _viewRenderService.RenderToStringAsync("RegistrationPage", new RegistrationPageModel(_template, res.ContentId));
            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}