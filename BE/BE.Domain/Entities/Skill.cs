using BE.Domain.Common;
using BE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Skill:EntityBase<Guid>
    {
        
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Name { get; set; }
        public ProficiencyLevel Proficiency { get; set; } 





        
    }
}
