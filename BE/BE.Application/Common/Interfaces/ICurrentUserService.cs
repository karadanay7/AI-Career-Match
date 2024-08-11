using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}
