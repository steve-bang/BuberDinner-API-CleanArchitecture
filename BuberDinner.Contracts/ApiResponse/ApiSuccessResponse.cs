using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.ApiResponse
{
    /// <summary>
    /// This class is used to return the response of the API
    /// </summary>
    /// <typeparam name="T">The type of the data that will be returned</typeparam>
    public class ApiSuccessResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public ApiSuccessResponse() { }

        public ApiSuccessResponse(T data) : base((int)HttpStatusCode.OK, success: true)
        {
            Data = data;
        }

        public ApiSuccessResponse(int httpCode, T data) : base(httpCode, success: true)
        {
            Data = data;
        }
    }
}
