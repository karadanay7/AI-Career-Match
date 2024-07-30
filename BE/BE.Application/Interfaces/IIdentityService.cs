using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> IsEmailExistsAsync(string email,CancellationToken cancellationToken);
    }
}
