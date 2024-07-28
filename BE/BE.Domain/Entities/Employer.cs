using BE.Domain.Enums;
using BE.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Employer:User
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string? Title { get; set; }
        public string? Department { get; set; }
    
      


    }
}
