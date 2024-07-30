using BE.Application.Features.UserAuth.Commands.UserRegister;
using BE.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserEmployeeRegister
{
    public class UserEmployeeRegisterCommandHandler : IRequestHandler<UserEmployeeRegisterCommand, ResponseDto<RegisterDto>>
    {





        public Task<ResponseDto<RegisterDto>> Handle(UserEmployeeRegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
