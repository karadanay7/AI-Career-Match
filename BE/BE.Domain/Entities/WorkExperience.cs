﻿using BE.Domain.Common;
using BE.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities
{
    public class WorkExperience: EntityBase<Guid>
    {
        
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? Responsibilities { get; set; }
       
    }
}
