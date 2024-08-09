using BE.Application.Common.Models.EmailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailResetPasswordAsync(EmailSendResetPasswordDto emailDto, CancellationToken cancellationToken);
        Task SendEmailVerificationAsync(EmailSendVerificationDto emailSendVerificationDto, CancellationToken cancellationToken);
        Task SendPasswordChangedNotificationAsync(string email,CancellationToken cancellationToken);
    }
}
