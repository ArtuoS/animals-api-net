using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Common.Interfaces
{
    public interface IResponseMany<T>
    {
        ResponseMany<T> SuccessModel(IList<T> data = default(IList<T>));
        ResponseMany<T> FailedModel();
    }
}
