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
            Configuration = configuration
        }

        public IConfiguration Configuration { get; set; }

        public ITemplate InitTemplate(TemplateType templateType, SenderType senderType)
        {
            switch(templateType)
            {
                case TemplateType.SsoRegistrationDefault:
                    return new ConfirmationEmailTemplate(InitCredentials(senderType));
                default:
                    throw new NoTemplateSelectedException();
            }
        }

        private Credentials InitCredentials(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                    return new Credentials(Configuration[$"{nameof(senderType)}_Username"], Configuration[$"{nameof(senderType)}_Password"]);
                default:
                    return new Credentials(Configuration[$"Username"], Configuration[$"Password"]);
            }
        }

    }
}
