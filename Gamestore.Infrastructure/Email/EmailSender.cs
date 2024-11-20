using Gamestore.Domain.Model;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using IEmailSender = Gamestore.Application.Contracts.Email.IEmailSender;

namespace Gamestore.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailOptions _options { get; }

    public EmailSender(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_options.ApiKey);
        var reciever = new EmailAddress(email.Reciever);
        var from = new EmailAddress
        {
            Email = _options.SenderAddress,
            Name = _options.Sendername,
        };

        var message = MailHelper.CreateSingleEmail(from, reciever, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}
