using Magnus.Emails.Helpers.Exceptions;
using Magnus.Emails.Interfaces;
using Magnus.Emails.Models;
using Magnus.Emails.Templates.Helpers;
using Magnus.Emails.Templates.SSO;

namespace Magnus.Emails.Helpers
{
    public class TemplateFactory
    {
        public TemplateFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public ITemplate InitTemplate(TemplateType templateType, SenderType senderType)
        {
            switch (templateType)
            {
                case TemplateType.SsoRegistrationDefault:
                    return new RegistrationDefaultTemplate(InitCredentials(senderType), InitEmailData(senderType));
                default:
                    throw new NoTemplateSelectedException();
            }
        }

        private Credentials InitCredentials(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                case SenderType.FutBot:
                    return new Credentials(Configuration[$"{senderType}:Email:Username"], Configuration[$"{senderType}:Email:Password"]);
                default:
                    return new Credentials(Configuration[$"Username"], Configuration[$"Password"]);
            }
        }

        private EmailData InitEmailData(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                    return new EmailData("Email Confirmation for Magnus Warehouse", "Magnus Warehouse", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
                case SenderType.FutBot:
                    return new EmailData("Email Confirmation for Magnus Fut Bot", "Magnus Fut Bot", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
                default:
                    return new EmailData("Email Confirmation for Magnus SSO", "Magnus SSO", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
            }
        }
    }
}
