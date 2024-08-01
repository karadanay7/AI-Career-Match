using BE.Application.Models;
using BE.Domain.Enums;
using BE.Domain.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserRegister
{
    public class UserEmployeeRegisterCommand:IRequest<ResponseDto<RegisterDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
        public string ConfirmPassword{ get; set; }


        public static User ToUser(UserEmployeeRegisterCommand command)
        {
            var id = Guid.NewGuid();

            return new User()
            {
                Id = id,
                FirstName= command.FirstName,
                LastName= command.LastName,
                UserName=command.FirstName+command.LastName,
                Email= command.Email,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = id.ToString(),
                UserType=UserType.Employee,
                EmailConfirmed = false,
            };
        }

    }
}
