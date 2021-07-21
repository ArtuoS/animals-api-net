using AnimalAPI.Common.Interfaces;

namespace AnimalAPI.Common
{
    public class Response<T> : IResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public Response<T> FailedModel()
        {
            return new Response<T>()
            {
                Success = false
            };
        }

        public Response<T> SuccessModel(T data = default)
        {
            return new Response<T>()
            {
                Data = data,
                Success = true
            };
        }
    }
}