using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Features.Auth.Commands
{
    public class RegisterCommandBehavior : AbstractValidator<RegisterCommand>
    {
        /// <summary>
        /// The minimum length of the password
        /// </summary>
        public const int MinPasswordLength = 6;

        /// <summary>
        /// The password must contain at least one uppercase letter, one lowercase letter, and one number
        /// </summary>
        public const string RegexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";

        public RegisterCommandBehavior()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(MinPasswordLength).WithMessage($"Password must be at least {MinPasswordLength} characters")
                .Matches(RegexPassword).WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");

        }
    }
}
