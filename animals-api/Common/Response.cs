using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Common
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
