using BE.Domain.Enums;
using BE.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Education: EntityBase<Guid>
    {
        public string Institution { get; set; }
        public DegreeType Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? Description { get; set; }
        public string Grade { get; set; }
    }
}
