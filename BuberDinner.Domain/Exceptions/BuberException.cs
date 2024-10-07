using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Exceptions
{
    public class BuberException : Exception
    {
        public int? Status { get; set; }

        public string Code { get; set; }

        public BuberException(string message) : base(message)
        {
        }

        public BuberException(string message, int status) : base(message)
        {
            Status = status;
        }

        public BuberException(int status, string code, string message) : base(message)
        {
            Status = status;
            Code = code;
        }
    }
}
