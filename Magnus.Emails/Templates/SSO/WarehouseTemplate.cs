using Magnus.Emails.Models;

namespace Magnus.Emails.Templates.SSO
{
    public class WarehouseRegistrationTemplate : BaseTemplate
    {
        public WarehouseRegistrationTemplate(Credentials credentials) : base(credentials)
        {
            Subject = "Email Confirmation for Magnus Warehouse";
            SiteName = "Magnus Warehouse";
            LogoPath = "./wwwroot/logos/warehouse/warehouse-flat-logo.png";
        }
    }
}
