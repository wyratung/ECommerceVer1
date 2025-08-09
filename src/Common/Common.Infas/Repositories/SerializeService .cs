﻿using Common.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infas.Repositories
{
    public class SerializeService : ISerializeService
    {
        public string Seriallize<T>(T obj)
        {
            var convertSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter>
            {
                new StringEnumConverter
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }
            };
            return JsonConvert.SerializeObject(obj, convertSettings);
        }

        public string Seriallize<T>(T obj, Type type)
        {
            return JsonConvert.SerializeObject(obj, type, new JsonSerializerSettings());
        }

        public T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}
