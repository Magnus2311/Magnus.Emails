using Magnus.Emails.Interfaces;
using Magnus.Emails.Models;

namespace Magnus.Emails.Templates
{
    public abstract class BaseTemplate : ITemplate
    {
        public BaseTemplate(Credentials credentials)
        {
            Credentials = credentials;
        }

        public Credentials Credentials { get; }

        public string? SiteName { get; init; }

        public string? LogoPath { get; init; }

        public string? Subject { get; init; }

        public string? Receiver { get; set; }

        public string? CallbackToken { get; set; }
    }
}
