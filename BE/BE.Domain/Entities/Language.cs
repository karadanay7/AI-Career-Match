using BE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Language
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public BE.Domain.Enums.Language Name { get; set; } 
        public LanguageProficiencyLevel Proficiency {  get; set; } 
    }
}
