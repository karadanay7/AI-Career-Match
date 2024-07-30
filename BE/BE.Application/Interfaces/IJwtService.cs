using BE.Application.Models;
using BE.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces
{
    public interface IJwtService
    {
       Task<JwtDto> GenerateTokenAsync(Guid userId, string email, List<string> roles, CancellationToken cancellationToken);

    }
}
