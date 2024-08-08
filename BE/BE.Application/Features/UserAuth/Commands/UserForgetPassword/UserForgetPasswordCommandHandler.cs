using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using BE.Application.Common.Models.EmailDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserForgetPassword
{
    public class UserForgetPasswordCommandHandler : IRequestHandler<UserForgetPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;

        private readonly IEmailService _emailService;

        public UserForgetPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<bool>> Handle(UserForgetPasswordCommand request, CancellationToken cancellationToken)
      
            {
                var response = await _identityService.ForgotPasswordAsync(request.Email, cancellationToken);

                var sendEmailTask = SendEmailForgotPasswordAsync(response.Email, response.FirstName, response.EmailToken, cancellationToken);

                await Task.WhenAll(sendEmailTask);
                return new ResponseDto<bool>(true, "Email Sended");
            }

            private Task SendEmailForgotPasswordAsync(string email, string firstName, string emailToken, CancellationToken cancellationToken)
            {
                var emailDto = new EmailSendResetPasswordDto(email, firstName, emailToken);

                return _emailService.SendEmailResetPasswordAsync(emailDto, cancellationToken);
            }
        }
}
