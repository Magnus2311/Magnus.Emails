using Magnus.Emails.Models;
using Magnus.Emails.Templates.Helpers;

namespace Magnus.Emails.Interfaces
{
    public interface ITemplate
    {
        public TemplateType TemplateType { get; protected set; }
        public Credentials Credentials { get; }
        public string? Subject { get; }
        public string? Receiver { get; set; }
        public string? CallbackToken { get; set; }
        public string? SiteName { get; }
        public string? LogoPath { get; }
    }
}
