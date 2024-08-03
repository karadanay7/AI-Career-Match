using BE.Application.Common.Interfaces;
using BE.Application.Common.Models.EmailDtos;
using Resend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BE.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {
        private readonly IResend _resend;

        public ResendEmailManager(IResend resend) { _resend = resend; }

        private const string ApiBaseUrl = "https://localhost:7057/api";
        public Task SendEmailVerificationAsync(EmailSendVerificationDto emailSendVerificationDto, CancellationToken cancellationToken)
        {
            var encodedEmail= HttpUtility.UrlEncode(emailSendVerificationDto.Email);
            var encodedToken = HttpUtility.UrlEncode(emailSendVerificationDto.Token);

            var link = $"{ApiBaseUrl}Users/verify-email?email={encodedEmail}&token={encodedToken}";

            var message = new EmailMessage();
            message.From = "onboarding@resend.dev";
            message.To.Add(emailSendVerificationDto.Email);
            message.Subject = "Email Verification | AI-Career-Match";
            message.HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>";

            return _resend.EmailSendAsync(message, cancellationToken);
        }
    }
}
