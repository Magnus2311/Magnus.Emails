using Magnus.Emails.Models;
using Magnus.Emails.Models.DTOs;
using Magnus.Emails.Models.Interfaces;

namespace Magnus.Emails.Templates.SSO
{
    public class ResetPasswordTemplate : BaseTemplate
    {
        public ResetPasswordTemplate(Credentials credentials,
        IEmailData emailData,
        ResetPasswordEmailDTO registrationEmailDTO)
            : base(credentials, emailData)
        {
            TemplateType = Helpers.TemplateType.ResetPasswordDefault;
            Username = registrationEmailDTO.Username;
        }

        public string? Username { get; }
    }
}
