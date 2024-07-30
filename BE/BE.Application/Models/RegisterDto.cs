using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Models
{
    public class RegisterDto
    {
        public Guid UserId { get; set; }
        public JwtDto JwtDto { get; set; }
    }
}
