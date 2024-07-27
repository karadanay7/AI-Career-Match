using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Common
{
    public interface  ICreatedByEntity
    {
        DateTimeOffset CreateOn { get; set; }
        string CreatedByUserId { get; set; }
    }
}
