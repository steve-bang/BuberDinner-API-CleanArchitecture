using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.ApiResponse
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public int? Code { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(int? code)
        {
            Code = code;
        }

        public ApiResponse(int? code, bool success)
        {
            Code = code;
            Success = success;
        }
    }
}
