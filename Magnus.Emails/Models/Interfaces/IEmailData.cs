namespace Magnus.Emails.Models.Interfaces
{
    public interface IEmailData
    {
        public string Subject { get; }
        public string SiteName { get; }
        public string LogoPath { get; }
    }
}