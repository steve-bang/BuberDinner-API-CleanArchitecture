using BuberDinner.Contracts.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.ApiResponse
{
    public class ApiErrorResponse : ApiResponse
    {
        public Error? Error { get; set; }

        public ApiErrorResponse() { }

        public ApiErrorResponse(Error error)
        {
            Success = false;
            Error = error;
        }

        public ApiErrorResponse(int httpCode, Error errror) : base(httpCode, success: false)
        {
            Error = errror;
        }
    }
}
