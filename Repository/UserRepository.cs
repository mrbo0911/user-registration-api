using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private ApplicationDbContext _repositoryContext;

        public UserRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await FindAll()
                        .OrderBy(User => User.UserName)
                        .ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await FindByCondition(user => user.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            Create(user);
            await SaveAsync();
        }

        public async Task UpdateUser(User dbUser, User user)
        {
            dbUser.Map(user);
            Update(dbUser);
            await SaveAsync();
        }

        public async Task DeleteUser(User user)
        {
            Delete(user);
            await SaveAsync();
        }
    }
}