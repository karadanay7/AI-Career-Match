using BE.Domain.Common;
using BE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Company:EntityBase<Guid>
    {
        public string Name { get; set; }
        public Industry Industry { get; set; }
        public DateTimeOffset FoundedYear { get; set; }
        public string? Description { get; set; }
        public List<string>? SocialMedia { get; set; }
        public string? Logo { get; set; }
        public List<Address>? Locations { get; set; }
        public List<JobPosting>? OpenPositions { get; set; }
        public List<Employer>? Employers { get; set; }
        public List<String>? Benefits { get; set; }

    }
}
