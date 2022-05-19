using Magnus.Emails.Templates.Helpers;

namespace Magnus.Emails.Models.DTOs
{
    public record RegistrationEmailDTO
    {
        public SenderType SenderType { get; init; }
        public string? Email { get; init; }
        public string? Token { get; init; }
    }
}
