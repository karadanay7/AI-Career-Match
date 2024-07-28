using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Enums
{
    public enum ApplicationStatus
    {
        Submitted=1,
        UnderReview=2,
        Rejected=3,
        Shortlisted=4,
        InterviewScheduled=5,
        Hired=6,
        Withdrawn=7
    }
}
