using Magnus.Emails.Interfaces;
using Magnus.Emails.Models;
using Magnus.Emails.Pages;
using Magnus.Emails.Templates.Helpers;
using Magnus.Emails.Templates.SSO;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var pageData = GetPageData(res.ContentId);
            var htmlBody = await _viewRenderService.RenderToStringAsync(pageData.PageName, pageData.PageModel);
            var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        private (string PageName, dynamic PageModel) GetPageData(string contentId)
        {
            switch (_template.TemplateType)
            {
                case TemplateType.FutBotRegistration:
                case TemplateType.SsoRegistrationDefault:
                    if (_template is RegistrationDefaultTemplate registrationDefaultTemplate)
                        return ("RegistrationPage", new RegistrationPageModel(registrationDefaultTemplate, contentId));
                    break;
                case TemplateType.ResetPasswordDefault:
                    if (_template is ResetPasswordTemplate resetPasswordTemplate)
                        return ("ResetPasswordPage", new ResetPasswordPageModel(resetPasswordTemplate, contentId));
                    break;
            }
            return ("", new RegistrationPageModel((_template as RegistrationDefaultTemplate)!, contentId));
        }
    }
}