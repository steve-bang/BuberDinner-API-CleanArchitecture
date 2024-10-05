using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";

        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpriryMinutes { get; set; }
        public string Audience { get; set; }
    }

}
