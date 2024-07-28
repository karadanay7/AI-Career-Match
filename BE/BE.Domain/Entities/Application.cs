using BE.Domain.Common;
using BE.Domain.Enums;
using BE.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Application:EntityBase<Guid>
    {
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTimeOffset ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
    }
}
