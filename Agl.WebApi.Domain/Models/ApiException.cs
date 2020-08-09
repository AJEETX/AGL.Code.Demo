using System;

namespace Agl.WebApi.Domain.Models
{
    public class ApiException : Exception
    {
        public int StatusCode { get;}
        public string Content { get;}
        public ApiException(int statusCode, string content)
        {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
