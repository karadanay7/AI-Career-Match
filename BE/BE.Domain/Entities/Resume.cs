using BE.Domain.Common;
using BE.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class Resume:EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string ResumeUrl { get; set; } 
        public string Description { get; set; }
        public DateTimeOffset UploadedDate { get; set; }
    }
}
