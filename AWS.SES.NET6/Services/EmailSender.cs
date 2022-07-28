using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AWS.SES.NET6.Interfaces;

namespace AWS.SES.NET6.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly IAmazonSimpleEmailService _amazonEmailService;

        public EmailSender(
            ILogger<EmailSender> logger,
            IAmazonSimpleEmailService amazonEmailService)
        {
            _logger = logger;
            _amazonEmailService = amazonEmailService;
        }
        public async Task<SendEmailResponse> SendEmailAsync(string to, string from, string subject, string body)
        {
            var emailRequest = new SendEmailRequest(
                from,
                new Destination(new List<string> { to }),
                new Message(new Content(subject), new Body(new Content(body)))
                );
            var response = await _amazonEmailService.SendEmailAsync(emailRequest);
            return response;
        }
    }
}
