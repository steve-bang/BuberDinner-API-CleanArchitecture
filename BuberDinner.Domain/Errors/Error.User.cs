using BuberDinner.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Errors
{
    public partial class Error
    {
        public static class User
        {
            public static BadRequestException EmailInvalid => new BadRequestException( "User.EmailInvalid", "The email address is invalid.");

            public static BadRequestException EmailAlreadyExists => new BadRequestException("User.EmailAlreadyExists", "The email address already exists.");

            public static BadRequestException PasswordInvalid => new BadRequestException("User.PasswordInvalid", "The password is invalid.");

            public static BadRequestException UsernameInvalid => new BadRequestException("User.UsernameInvalid", "The username is invalid.");

            public static BadRequestException SurnameInvalid => new BadRequestException("User.SurnameInvalid", "The surname is invalid.");

            public static DataNotFoundException UserNotFound => new DataNotFoundException("User.UserNotFound", "The user was not found.");

            public static BadRequestException UserAlreadyExists => new BadRequestException("User.UserAlreadyExists", "The user already exists.");

            public static BadRequestException UserNotCreated => new BadRequestException("User.UserNotCreated", "The user was not created.");

            public static BadRequestException UserNotUpdated => new BadRequestException("User.UserNotUpdated", "The user was not updated.");

            public static BadRequestException UserNotDeleted => new BadRequestException("User.UserNotDeleted", "The user was not deleted.");

            public static BadRequestException UserNotActivated => new BadRequestException("User.UserNotActivated", "The user was not activated.");

            public static BadRequestException UserNotDeactivated => new BadRequestException("User.UserNotDeactivated", "The user was not deactivated.");

            public static BadRequestException UserNotAuthenticated => new BadRequestException("User.UserNotAuthenticated", "The user was not authenticated.");

            public static BadRequestException UserNotAuthorized => new BadRequestException("User.UserNotAuthorized", "The user was not authorized.");

            public static BadRequestException UserNotConfirmed => new BadRequestException("User.UserNotConfirmed", "The user was not confirmed.");

            public static BadRequestException UserNotForgotPassword => new BadRequestException("User.UserNotForgotPassword", "The user was not forgot password.");

            public static BadRequestException UserNotResetPassword => new BadRequestException("User.UserNotResetPassword", "The user was not reset password.");

            public static BadRequestException UserNotChangedPassword => new BadRequestException("User.UserNotChangedPassword", "The user was not changed password.");

            public static BadRequestException UserNotChangedEmail => new BadRequestException("User.UserNotChangedEmail", "The user was not changed email.");

            public static BadRequestException UserNotChangedUsername => new BadRequestException("User.UserNotChangedUsername", "The user was not changed username.");

            public static BadRequestException UserNotChangedSurname => new BadRequestException("User.UserNotChangedSurname", "The user was not changed surname.");

            public static DataNotFoundException EmailNotFound => new DataNotFoundException("User.EmailNotFound", "The email was not found.");

            public static DataNotFoundException UsernameNotFound => new DataNotFoundException("User.UsernameNotFound", "The username was not found.");
        }
    }
}
