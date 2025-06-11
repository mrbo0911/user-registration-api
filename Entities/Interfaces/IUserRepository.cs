using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserByIdAsync(Guid id);

        Task<User> GetUserByIcNumberAsync(string icNumber);

        Task CreateUser(User user);

        Task UpdateUser(User dbuser, User user);

        Task DeleteUser(User user);
    }
}
