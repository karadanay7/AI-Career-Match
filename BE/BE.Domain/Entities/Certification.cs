using BE.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Certification:EntityBase<Guid>
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public String Name { get; set; }
        public string Authority { get; set; }
        public DateTimeOffset DateRecevied { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }
        public string? Description { get; set; }

    }
}
