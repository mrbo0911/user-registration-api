using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Interfaces;
using UserRegistration.Infrastructure.Persistence;

namespace UserRegistration.Infrastructure.Repositories
{
    public class PhoneOtpRepository : RepositoryBase<PhoneOtp>, IPhoneOtpRepository
    {
        public PhoneOtpRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<PhoneOtp>> GetAllPhoneOtpsAsync()
        {
            return await FindAll()
                        .OrderBy(otp => otp.SentAt)
                        .ToListAsync();
        }

        public async Task<PhoneOtp> GetPhoneOtpByIdAsync(Guid id)
        {
            return await FindByCondition(otp => otp.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<PhoneOtp> GetPhoneOtpByIcNumberAsync(string icNumber)
        {
            return await FindByCondition(otp => otp.IcNumber.Equals(icNumber))
                        .FirstOrDefaultAsync();
        }

        public async Task CreatePhoneOtpAsync(PhoneOtp otp)
        {
            Create(otp);
            await SaveAsync();
        }

        public async Task UpdatePhoneOtpAsync(PhoneOtp otp)
        {
            Update(otp);
            await SaveAsync();
        }

        public async Task DeletePhoneOtpAsync(PhoneOtp otp)
        {
            Delete(otp);
            await SaveAsync();
        }
    }
}