using BE.Domain.Common;
using BE.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Identity
{
    public abstract class User : IdentityUser<Guid>, IEntity<Guid>, ICreatedByEntity, IModifiedByEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImage { get; set; }
        public DateTimeOffset CreateOn { get; set ; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public UserType UserType { get; set; }
    }
}
