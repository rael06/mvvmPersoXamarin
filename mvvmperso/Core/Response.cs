using System;
namespace mvvmperso.Core
{
    public class Response<T>
    {
        public T Data { get; }
        public Exception Error { get; }
        public bool IsSuccess => Error == null;

        public Response(T data)
        {
            Data = data;
        }

        public Response(Exception exception)
        {
            Error = exception;
        }

    }
}
