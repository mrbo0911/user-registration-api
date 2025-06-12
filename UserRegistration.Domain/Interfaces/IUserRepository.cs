using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserByIcNumberAsync(string icNumber);

        Task CreateUser(User user);

        Task UpdateUser(User dbUser, User user);

        Task DeleteUser(User user);

        Task AcceptConsentPrivacy(User user);

        Task CreatePin(User user);

        Task EnableBiometric(User user);
    }
}
