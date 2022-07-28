using Amazon.SimpleEmail.Model;

namespace AWS.SES.NET6.Interfaces
{
    public interface IEmailSender
    {
        Task<SendEmailResponse> SendEmailAsync(string to, string from, string subject, string body);
    }
}
