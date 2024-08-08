using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserForgetPassword
{
    public class UserForgetPasswordCommand:IRequest<ResponseDto<bool>>
    {
        public string Email { get; set; }
    }
}
