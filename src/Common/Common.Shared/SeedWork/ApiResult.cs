using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.SeedWork
{
    public class ApiResult<T>
    {
        public ApiResult()
        {

        }

        public ApiResult(bool isSucceeded, string? message = default)
        {
            Message = message;
            IsSucceeded = isSucceeded;
        }

        public ApiResult(bool isSucceeded, T data, string? message = default)
        {
            Data = data;
            Message = message;
            IsSucceeded = isSucceeded;
        }

        public string? Message { get; set; }
        public bool IsSucceeded { get; set; }
        public T? Data { get; set; }
    }
}
