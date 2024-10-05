
using BuberDinner.Application.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // 1. Check if user exists

            // 2. Generate token

            Guid userId = Guid.NewGuid();

            string token = _jwtTokenGenerator.GenerateToken(userId, email, email);

            return new AuthenticationResult()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = email,
                Token = token
            };
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // 1. Check if user already exists

            // 2. Create user   

            // 3. Generate token
            Guid userId = Guid.NewGuid();

            string token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Token = token
            };
        }
    }
}
