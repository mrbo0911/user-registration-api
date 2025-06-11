using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Interfaces
{
    public interface IOtpRepository : IRepositoryBase<Otp>
    {
        Task<IEnumerable<Otp>> GetAllOtpsAsync();

        Task<Otp> GetOtpByIdAsync(Guid id);

        Task<Otp> GetOtpByPhoneNumberAsync(string phoneNumber);

        Task CreateOtpAsync(Otp otp);

        Task UpdateOtpAsync(Otp dbOtp, Otp otp);

        Task DeleteOtpAsync(Otp otp);
    }
}
