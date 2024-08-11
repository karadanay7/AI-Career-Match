﻿using BE.Application.Common.Interfaces;
using System.Security.Claims;

namespace BE.WebApi.Services
{
    public class CurrentUserManager : ICurrentUserService
    {
       private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid UserId => GetUserId();

        private Guid GetUserId()
        {
            var userId = _contextAccessor.HttpContext?.User?.FindFirstValue("uid");
            return userId is null ? Guid.Empty: Guid.Parse(userId);
        }
    }
}
