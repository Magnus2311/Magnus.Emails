using Magnus.Emails.Models;

namespace Magnus.Emails.Interfaces
{
    public interface ITemplate
    {
        public Credentials Credentials { get; }
        public string? Subject { get; }
        public string? Receiver { get; }
        public string? CallbackToken { get; }
        public string? SiteName { get; }
        public string? LogoPath { get; }
    }
}
