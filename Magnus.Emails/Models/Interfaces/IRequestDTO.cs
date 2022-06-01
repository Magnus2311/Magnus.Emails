using Magnus.Emails.Templates.Helpers;

namespace Magnus.Emails.Models.Interfaces
{
    public interface IRequestDTO
    {
        SenderType SenderType { get; init; }
        string? Email { get; init; }
        string? Token { get; init; }
    }
}