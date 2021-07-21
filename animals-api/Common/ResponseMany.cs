using AnimalAPI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Common
{
    public class ResponseMany<T> : IResponseMany<T>
    {
        public bool Success { get; set; }
        public IList<T> Data { get; set; }

        public ResponseMany<T> FailedModel()
            => new ResponseMany<T>()
            {
                Success = false,

            };

        public ResponseMany<T> SuccessModel(IList<T> data = null)
            => new ResponseMany<T>()
            {
                Data = data,
                Success = true,
            };
    }
}
