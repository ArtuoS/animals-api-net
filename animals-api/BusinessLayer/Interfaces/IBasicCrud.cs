using AnimalAPI.Common;
using AnimalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.BusinessLayer.Interfaces
{
    public interface IBasicCrud<T>
    {
        Task<Response<T>> GetById(long id);
        Task<Response<T>> Delete(long id);
        Task<Response<T>> Create(T item);
        Task<Response<T>> Update(int id, Animal animal);
        Task<ResponseMany<T>> GetAll();
    }
}
