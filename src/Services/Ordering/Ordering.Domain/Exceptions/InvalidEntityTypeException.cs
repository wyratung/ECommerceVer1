using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Exceptions
{
    public class InvalidEntityTypeException : ApplicationException
    {
        public InvalidEntityTypeException()
        {

        }

        public InvalidEntityTypeException(string message) : base(message)
        {

        }

        public InvalidEntityTypeException(string entity, object type)
            : base($"Entity \"{entity}\" not supported type: {type}.")
        {

        }
    }
}
