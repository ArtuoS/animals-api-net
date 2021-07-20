using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Common
{
    public class ResponseMany<T>
    {
        public bool Success { get; set; }
        public List<T> Data { get; set; }
    }
}
