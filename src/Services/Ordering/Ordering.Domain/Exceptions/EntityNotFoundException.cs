using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(string message) : base(message)
        {

        }

        public EntityNotFoundException(string entity, object key)
            : base($"Entity \"{entity}\" {key} was not found.")
        {

        }
    }
}
