using BuberDinner.Application.Common.Intefaces.Persistence;
using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new();

        public async Task AddAsync(User user)
        {
            await Task.Run(() => _users.Add(user));
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await Task.FromResult(_users.Any(u => u.Email == email));
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.Email == email));
        }
    }
}
