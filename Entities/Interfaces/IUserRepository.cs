using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserRegistration.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(Guid id);

        Task<User> GetUserByIcNumber(string icNumber);

        Task CreateUser(User user);

        Task UpdateUser(User dbuser, User user);

        Task DeleteUser(User user);
    }
}
