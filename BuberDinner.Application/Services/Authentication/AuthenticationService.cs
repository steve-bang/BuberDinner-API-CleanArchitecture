
using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
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

        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="jwtTokenGenerator">The jwt token generator.</param>
        /// <param name="userRepository">The user repository.</param>
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Login(string email, string password)
        {
            // 1. Check if user exists
            var user = await _userRepository.GetByEmailAsync(email);

            if(user == null)
            {
                throw new Exception("The email or password is incorrect");
            }


            // 2. Check if password is correct
            if (user.Password != password)
            {
                throw new Exception("The email or password is incorrect");
            }


            // 3. Generate token
            string token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
        }

        public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate email if the user already exists
            bool existsEmail = await _userRepository.ExistsEmailAsync(email);

            if (existsEmail)
            {
                throw new Exception("Email already exists");
            }


            // 2. Create user   
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };


            // 3. Generate token
            await _userRepository.AddAsync(user);

            string token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult()
            {
                Id = user.Id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Token = token
            };
        }
    }
}
