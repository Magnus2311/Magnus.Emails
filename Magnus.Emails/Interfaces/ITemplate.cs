using Magnus.Emails.Models;

namespace Magnus.Emails.Interfaces
{
    public interface ITemplate
    {
        public Credentials Credentials { get; }
        public string? Subject { get; }
        public string? Receiver { get; set; }
        public string? CallbackToken { get; set; }
        public string? SiteName { get; }
        public string? LogoPath { get; }
    }
}
