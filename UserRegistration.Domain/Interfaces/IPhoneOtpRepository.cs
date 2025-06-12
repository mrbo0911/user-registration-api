using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Interfaces
{
    public interface IPhoneOtpRepository : IRepositoryBase<PhoneOtp>
    {
        Task<IEnumerable<PhoneOtp>> GetAllPhoneOtpsAsync();

        Task<PhoneOtp> GetPhoneOtpByIdAsync(Guid id);

        Task<PhoneOtp> GetPhoneOtpByIcNumberAsync(string icNumber);

        Task CreatePhoneOtpAsync(PhoneOtp otp);

        Task UpdatePhoneOtpAsync(PhoneOtp otp);

        Task DeletePhoneOtpAsync(PhoneOtp otp);
    }
}
