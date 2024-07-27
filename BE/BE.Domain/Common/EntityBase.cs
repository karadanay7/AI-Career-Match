using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Common
{
    public class EntityBase : IModifiedByEntity, ICreatedByEntity, IEntity<Guid>
    {
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public string CreatedByUserId { get; set; }
        public Guid Id { get; set; }
    }
}
