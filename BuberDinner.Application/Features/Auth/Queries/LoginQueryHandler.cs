using BuberDinner.Application.Common.Intefaces.Authentication;
using BuberDinner.Application.Common.Intefaces.Persistence;
using BuberDinner.Application.Features.Auth.Common;
using BuberDinner.Domain.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Features.Auth.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository
        )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // 1. Check if user exists
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw BuberError.User.EmailNotFound;
            }


            // 2. Check if password is correct
            if (user.Password != request.Password)
            {
                throw BuberError.User.PasswordInvalid;
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
    }
}
