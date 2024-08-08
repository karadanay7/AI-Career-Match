using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Models.User
{
    public class UserRegisterResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string EmailToken { get; set; }


        public UserRegisterResponseDto(Guid id, string email, string firstName, string emailToken)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            EmailToken = emailToken;
        }
    }
}
