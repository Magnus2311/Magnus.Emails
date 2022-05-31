namespace Magnus.Emails.Templates.Helpers
{
    public enum TemplateType
    {
        SsoRegistrationDefault = 0,
        FutBotRegistration = 1,
        ResetPasswordDefault = 2
    }

    public enum SenderType
    {
        Default,
        Warehouse = 1,
        FutBot = 2
    }
}
