using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Exceptions
{
    public class BadRequestException : BuberException
    {

        public BadRequestException(string message) : base(message, 400)
        {
        }

        public BadRequestException(string code, string message) : base(400, code, message)
        {
        }
    }
}
