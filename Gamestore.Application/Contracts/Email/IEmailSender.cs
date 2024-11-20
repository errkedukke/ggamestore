using Gamestore.Domain.Model;

namespace Gamestore.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
