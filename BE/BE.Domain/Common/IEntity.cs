using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Common
{
    public interface IEntity<TKEy>
    {
        public TKEy Id { get; set; }
    }
}
