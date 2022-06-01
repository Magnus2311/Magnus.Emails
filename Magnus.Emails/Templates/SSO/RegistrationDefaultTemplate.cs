using Magnus.Emails.Models;
using Magnus.Emails.Models.DTOs;
using Magnus.Emails.Models.Interfaces;

namespace Magnus.Emails.Templates.SSO
{
    public class RegistrationDefaultTemplate : BaseTemplate
    {
        public RegistrationDefaultTemplate(Credentials credentials,
        IEmailData emailData,
        RegistrationEmailDTO registrationEmailDTO) 
            : base(credentials, emailData)
        {
            TemplateType = Helpers.TemplateType.SsoRegistrationDefault;
        }
    }
}
