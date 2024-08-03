using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserVerifyEmail
{
    public class UserVerifyEmailCommand:IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public UserVerifyEmailCommand(string email, string token)
        {
            Email = email;
            Token = token;
        }

    }
}
