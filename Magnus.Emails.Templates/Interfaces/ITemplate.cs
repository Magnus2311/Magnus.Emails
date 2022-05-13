using Magnus.Emails.Templates.Helpers;

namespace Magnus.Emails.Templates.Interfaces
{
    public interface ITemplate
    {
        public TemplateTypes Type { get; init; }
        public string Sender { get; init; }
        public string Password { get; init; }
        public string SiteName { get; init; }
        public string LogoPath { get; init; }
    }
}
