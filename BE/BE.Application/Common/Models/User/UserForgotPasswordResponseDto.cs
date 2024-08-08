using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Models.User
{
    public class UserForgotPasswordResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string EmailToken { get; set; }

        public UserForgotPasswordResponseDto(Guid ıd, string email, string firstName, string emailToken)
        {
            Id = ıd;
            Email = email;
            FirstName = firstName;
            EmailToken = emailToken;
        }
    }
}
