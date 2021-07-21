using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Common.Interfaces
{
    public interface IResponse<T>
    {
        Response<T> SuccessModel(T data = default(T));
        Response<T> FailedModel();
    }
}
