using Magnus.Emails.Models.Interfaces;
using Magnus.Emails.Templates.Helpers;

namespace Magnus.Emails.Models.DTOs
{
    public record ResetPasswordEmailDTO : IRequestDTO
    {
        public SenderType SenderType { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
        public string? Token { get; init; }
    }
}
