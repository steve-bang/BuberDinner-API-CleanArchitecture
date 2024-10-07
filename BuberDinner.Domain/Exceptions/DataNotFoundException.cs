using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Exceptions
{
    public class DataNotFoundException : BuberException
    {

        public DataNotFoundException(string message) : base(message, 404)
        {
        }

        public DataNotFoundException(string code, string message) : base(404, code, message)
        {
        }
    }
}
