using BE.Domain.Common;
using BE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BE.Domain.Entities
{
    public class JobPosting:EntityBase<Guid>
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }

        public string Title { get; set; }
        public string DEscription { get; set; }
        public WorkStyle WorkStyle { get; set; }
        public Decimal? MinSalary { get; set; }
        public Decimal? MaxSalary { get;set; }
        public List<string> RequiredSkills { get; set; }
        public int? RequiredExperienceTime { get; set; }
        public DegreeType? RequiredEducationLevel { get; set; }
        public string? Responsibilities { get; set; }
        public string? Qualifications { get; set; }

        public List<string>? SpecificBenefits { get; set; }

        public DateTime? ApplicationDeadline { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool? IsActive { get; set; }
        public string? Department { get; set; }
        public List<Language>? RequiredLanguages { get; set; }
        public string? InterviewProcess { get; set; }
        public bool? TravelRequirement { get; set; }
        public int? ViewCount { get; set; }
        public int? ApplicationCount { get; set; }
        public List<Application>? Applications { get; set; }
       

    }
}
