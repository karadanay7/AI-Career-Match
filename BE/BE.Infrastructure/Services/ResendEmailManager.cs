﻿using BE.Application.Common.Interfaces;
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
        private readonly IRootPathService _rootPathService;

        public ResendEmailManager(IResend resend, IRootPathService rootPathService)
        {
            _resend = resend; _rootPathService = rootPathService;
        }

        private const string ApiBaseUrl = "https://localhost:7057/api/";
  


        public async Task SendEmailVerificationAsync(EmailSendVerificationDto emailDto, CancellationToken cancellationToken)
        {


            var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);

            var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

            var link = $"{ApiBaseUrl}verify-email?email={encodedEmail}&token={encodedToken}";

            var htmlContent =
                await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html", cancellationToken);

            htmlContent = htmlContent.Replace("{{{link}}}", link);

            htmlContent = htmlContent.Replace("{{{subject}}}", "Verify Your Email 🙏");

            htmlContent = htmlContent.Replace("{{{content}}}", $"Hello 👋,<br/><br/>Thank you for signing up with AI-Career-Match 😊 To complete your registration<br/><br/>If you did not request this, please ignore this email.<br/><br/>Best regards,<br/>The AI-Career-Match Team");

            htmlContent = htmlContent.Replace("{{{buttonText}}}", "Verify My Email Address");
            await SendEmailAsync(new EmailSendDto(emailDto.Email, "Verify Your Email Address | AI-Career-Match", htmlContent), cancellationToken);
        }

        public async Task SendEmailResetPasswordAsync(EmailSendResetPasswordDto emailDto, CancellationToken cancellationToken)
        {

            var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
            var encodedToken = HttpUtility.UrlEncode(emailDto.Token);
            var link = $"{ApiBaseUrl}Users/forgot-password?email={encodedEmail}&token={encodedToken}";

            var htmlContent = await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html", cancellationToken);
            htmlContent = htmlContent.Replace("{{{link}}}", link);
            htmlContent = htmlContent.Replace("{{{subject}}}", "Reset Your Password");
            htmlContent = htmlContent.Replace("{{{content}}}",
                $"Hello 👋,<br/><br/>We received a request to reset the password for your TherapAI account. " +
                $"Please click the button below to reset your password:<br/><br/>" +
                $"If you did not request this, please ignore this email.<br/><br/>" +
                $"Best regards,<br/>The TherapAI Team");

            htmlContent = htmlContent.Replace("{{{buttonText}}}", "Reset Your Password");

            await SendEmailAsync(new EmailSendDto(emailDto.Email, "Reset Your Password | TherapAI", htmlContent), cancellationToken);
        }


        public async Task SendPasswordChangedNotificationAsync(string email, CancellationToken cancellationToken)
        {
            var htmlContent = await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-notificationTemplate.html", cancellationToken);

            htmlContent = htmlContent.Replace("{{{subject}}}", "Your Password Has Been Changed");
            htmlContent = htmlContent.Replace("{{{content}}}",
                $"Hello 👋,<br/><br/>We wanted to let you know that your password for TherapAI has been successfully changed 👍" +
                $"If you did not make this change, please contact our support team immediately.<br/><br/>" +
                $"Best regards,<br/>The TherapAI Team");

            await SendEmailAsync(new EmailSendDto(email, "Password Changed Notification | TherapAI", htmlContent), cancellationToken);
        }

        private Task SendEmailAsync(EmailSendDto emailSendDto, CancellationToken cancellationToken)
        {
            var message = new EmailMessage();

            message.From = "onboarding@resend.dev";

            foreach (var emailAddress in emailSendDto.Addresses)
                message.To.Add(emailAddress);

            message.Subject = emailSendDto.Subject;
            message.HtmlBody = emailSendDto.HtmlContent;

            return _resend.EmailSendAsync(message, cancellationToken);
        }

       
    }
}
