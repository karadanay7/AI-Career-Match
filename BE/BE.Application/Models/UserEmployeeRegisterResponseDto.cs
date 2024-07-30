using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Models
{
    public class UserEmployeeRegisterResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string EmailToken { get; set; }


        public UserEmployeeRegisterResponseDto(Guid id, string email, string firstName, string emailToken)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            EmailToken = emailToken;
        }
    }
}
