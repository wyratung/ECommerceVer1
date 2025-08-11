using Common.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Events
{
    public class AuditableEventEntity<T> : EventEntity<T>, IAuditable
    {
        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}
