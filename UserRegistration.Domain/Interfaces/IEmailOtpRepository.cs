using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Interfaces
{
    public interface IEmailOtpRepository : IRepositoryBase<EmailOtp>
    {
        Task<IEnumerable<EmailOtp>> GetAllEmailOtpsAsync();

        Task<EmailOtp> GetEmailOtpByIdAsync(Guid id);

        Task<EmailOtp> GetEmailOtpByIcNumberAsync(string icNumber);

        Task CreateEmailOtpAsync(EmailOtp otp);

        Task UpdateEmailOtpAsync(EmailOtp otp);

        Task DeleteEmailOtpAsync(EmailOtp otp);
    }
}
