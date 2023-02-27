namespace Messaging;

public interface IEmailSender
{
    void SendEmail(EmailMessage message);
    Task SendEmailAsync(EmailMessage message);
}