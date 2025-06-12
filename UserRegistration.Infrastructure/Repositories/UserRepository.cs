using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Extensions;
using UserRegistration.Domain.Interfaces;
using UserRegistration.Infrastructure.Persistence;

namespace UserRegistration.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await FindAll()
                        .OrderBy(User => User.UserName)
                        .ToListAsync();
        }

        public async Task<User> GetUserByIcNumberAsync(string icNumber)
        {
            return await FindByCondition(user => user.IcNumber.Equals(icNumber))
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

        public async Task AcceptConsentPrivacy(User user)
        {
            Update(user);
            await SaveAsync();
        }

        public async Task CreatePin(User user)
        {
            Update(user);
            await SaveAsync();
        }

        public async Task EnableBiometric(User user)
        {
            Update(user);
            await SaveAsync();
        }
    }
}