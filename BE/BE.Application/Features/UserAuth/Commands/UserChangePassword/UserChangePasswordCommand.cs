using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserChangePassword
{
    public class UserChangePasswordCommand:IRequest<ResponseDto<bool>>
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
