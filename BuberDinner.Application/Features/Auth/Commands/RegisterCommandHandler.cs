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

namespace BuberDinner.Application.Features.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate email if the user already exists
            bool existsEmail = await _userRepository.ExistsEmailAsync(request.Email);

            if (existsEmail)
            {
                throw BuberError.User.EmailAlreadyExists;
            }


            // 2. Create user   
            var user = new Domain.Entities.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };


            // 3. Generate token
            await _userRepository.AddAsync(user);

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
