namespace Magnus.Emails.Interfaces
{
    public interface IEmailsService
    {
        Task SendEmail();
        Task ReSendRegistrationEmail(string url, string email, string token);
        Task SendResetPasswordEmail(string url, string email, string token, string template);
    }
}
