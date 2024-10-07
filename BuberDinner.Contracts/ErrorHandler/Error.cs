using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.ErrorHandler
{
    public class Error
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
    }
}
