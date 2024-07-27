using BE.Domain.Enums;
using BE.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Employee:User
    {
        public List<string>? ResumeUrls { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<WorkExperience>? Experiences { get; set; }
        public List<Education>? Educations { get; set; }
        public decimal? DesiredSalary { get; set; }
        public DateTimeOffset? AvailableFrom { get; set; }
        public List<Certification>? Certifications { get; set; }
        public List<Language>? Languages { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? GitHubProfile { get; set; }
        public string? MediumProfile { get; set; }
        public string? PortfolioURL { get; set; }
        public List<Reference>? References { get; set; }
        public Address? Address { get; set; }


        public Employee()
        {
            UserType = UserType.Employee;
        }

    }
}
