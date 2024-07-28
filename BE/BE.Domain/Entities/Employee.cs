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
        public List<Resume>? Resumes { get; set; }
        public string Title { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<WorkExperience>? Experiences { get; set; }
        public List<Education>? Educations { get; set; }
        public decimal? DesiredSalary { get; set; }
        public DateTimeOffset? AvailableFrom { get; set; }
        public List<Certification>? Certifications { get; set; }
        public List<Language>? Languages { get; set; }
        public List<WorkStyle> WorkStyles { get; set; }
        public List<string> SocialMediaUrl { get; set; }
        public List<Reference>? References { get; set; }
        public Address? Address { get; set; }


        public Employee()
        {
            UserType = UserType.Employee;
        }

    }
}
