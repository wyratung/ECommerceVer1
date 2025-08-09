using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Interfaces
{
    public interface ISerializeService
    {
        string? Seriallize<T>(T obj);
        string Seriallize<T>(T obj, Type type);
        T Deserialize<T>(string text);
    }
}
