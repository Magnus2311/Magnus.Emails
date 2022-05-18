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
                    return new WarehouseRegistrationTemplate(InitCredentials(senderType));
                default:
                    throw new NoTemplateSelectedException();
            }
        }

        private Credentials InitCredentials(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                    return new Credentials(Configuration[$"{senderType.ToString()}:Email:Username"], Configuration[$"{senderType.ToString()}:Email:Password"]);
                default:
                    return new Credentials(Configuration[$"Username"], Configuration[$"Password"]);
            }
        }

    }
}
