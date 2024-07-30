using BE.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE.Application.Common.FluentValidation.BaseValidators
{
    public class UserValidatioBase<T>:AbstractValidator<T> where T : class
    {
        protected readonly IIdentityService _identityService;

        public UserValidatioBase(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected bool IsEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }
    }
}
