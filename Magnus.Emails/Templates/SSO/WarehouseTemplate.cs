using Magnus.Emails.Models;

namespace Magnus.Emails.Templates.SSO
{
    public class WarehouseTemplate : BaseTemplate
    {
        public WarehouseTemplate(Credentials credentials) : base(credentials)
        {
            SiteName = "Warehouse";
            LogoPath = "~/";
        }
    }
}
