using BE.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Address:EntityBase<Guid>
    {
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
