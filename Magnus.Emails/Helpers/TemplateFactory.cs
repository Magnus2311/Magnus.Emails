using Magnus.Emails.Helpers.Exceptions;
using Magnus.Emails.Interfaces;
using Magnus.Emails.Models;
using Magnus.Emails.Models.DTOs;
using Magnus.Emails.Models.EmailTemplates;
using Magnus.Emails.Models.Interfaces;
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

        public ITemplate? InitTemplate(TemplateType templateType, IRequestDTO requestDTO)
        {
            switch (templateType)
            {
                case TemplateType.SsoRegistrationDefault:
                    if (requestDTO is RegistrationEmailDTO registrationEmailDTO)
                        return new RegistrationDefaultTemplate(InitCredentials(requestDTO.SenderType), InitRegistrationData(requestDTO.SenderType), registrationEmailDTO);
                    break;
                case TemplateType.ResetPasswordDefault:
                    if (requestDTO is ResetPasswordEmailDTO resetPasswordEmailDTO)
                        return new ResetPasswordTemplate(InitCredentials(requestDTO.SenderType), InitRegistrationData(requestDTO.SenderType), resetPasswordEmailDTO);
                    break;
                default:
                    throw new NoTemplateSelectedException();
            }

            return null;
        }

        private Credentials InitCredentials(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                case SenderType.FutBot:
                    return new Credentials(Configuration[$"{senderType}:Email:Username"], Configuration[$"{senderType}:Email:Password"]);
                default:
                    return new Credentials("magnus.sso.oss@gmail.com", Configuration[$"Password"]);
            }
        }

        private IEmailData InitRegistrationData(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                    return new RegistrationEmailData("Email Confirmation for Magnus Warehouse", "Magnus Warehouse", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
                case SenderType.FutBot:
                    return new RegistrationEmailData("Email Confirmation for Magnus Fut Bot", "Magnus Fut Bot", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
                default:
                    return new RegistrationEmailData("Email Confirmation for Magnus SSO", "Magnus SSO", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
            }
        }

        private IEmailData InitResetPasswordData(SenderType senderType)
        {
            switch (senderType)
            {
                case SenderType.Warehouse:
                    return new ResetPasswordEmailData("Reset password confirmation for Magnus Warehouse", "Magnus Warehouse", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
                case SenderType.FutBot:
                    return new ResetPasswordEmailData("Reset password confirmation for Magnus Fut Bot", "Magnus Fut Bot", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
                default:
                    return new ResetPasswordEmailData("Reset password confirmation for Magnus SSO", "Magnus SSO", "./wwwroot/logos/warehouse/warehouse-flat-logo.png");
            }
        }
    }
}
