﻿using BE.Application.Common.Models;
using BE.Application.Features.UserAuth.Commands.UserEmployeeRegister;
using BE.Domain.Enums;
using BE.Domain.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserEmployerRegister
{
    public class UserEmployerRegisterCommand : IRequest<ResponseDto<RegisterDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public static User ToUser(UserEmployerRegisterCommand command)
        {
            var id = Guid.NewGuid();

            return new User()
            {
                Id = id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.Email,
                Email = command.Email,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = id.ToString(),
                UserType = UserType.Employer,
                EmailConfirmed = true,
            };
        }
    }

  
}
