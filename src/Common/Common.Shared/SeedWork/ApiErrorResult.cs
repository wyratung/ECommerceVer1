using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.SeedWork
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public ApiErrorResult() : this("semething wrong happened. Please try again later")
        {

        }

        public ApiErrorResult(string message = "Error") : base(false, message)
        {

        }

        public ApiErrorResult(List<string> errors) : base(false)
        {
            Errors = errors;
        }

        public List<string> Errors { get; set; }
    }
}
