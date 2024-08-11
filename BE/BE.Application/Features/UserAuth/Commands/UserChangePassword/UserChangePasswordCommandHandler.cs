using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserChangePassword
{
    public class UserChangePasswordCommandHandler : IRequestHandler<UserChangePasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;
        public UserChangePasswordCommandHandler(IIdentityService identityService, ICurrentUserService currentUserService)
        {
            _identityService = identityService;
            _currentUserService = currentUserService;
        }



        public async Task<ResponseDto<bool>> Handle(UserChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ChangePasswordAsync(_currentUserService.UserId, request.CurrentPassword, request.NewPassword, cancellationToken);
            return new ResponseDto<bool>(true, "Password changed successfully");
        }
    }
}
