using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Persistence
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns the user by email.</returns>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Existses the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns true if the email exists, otherwise false.</returns>
        Task<bool> ExistsEmailAsync(string email);

        /// <summary>
        /// Adds the specified user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddAsync(User user);
    }
}
