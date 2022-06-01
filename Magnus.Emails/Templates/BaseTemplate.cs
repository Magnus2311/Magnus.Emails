using Magnus.Emails.Interfaces;
using Magnus.Emails.Models;
using Magnus.Emails.Models.Interfaces;
using Magnus.Emails.Templates.Helpers;

namespace Magnus.Emails.Templates
{
    public abstract class BaseTemplate : ITemplate
    {
        public BaseTemplate(Credentials credentials, IEmailData emailData)
        {
            Credentials = credentials;
            Subject = emailData.Subject;
            SiteName = emailData.SiteName;
            LogoPath = emailData.LogoPath;
        }

        public Credentials Credentials { get; }

        public string? SiteName { get; init; }

        public string? LogoPath { get; init; }

        public string? Subject { get; init; }

        public string? Receiver { get; set; }

        public string? CallbackToken { get; set; }

        public TemplateType TemplateType { get; set; }
    }
}
