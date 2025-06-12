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
    public class EmailOtpRepository : RepositoryBase<EmailOtp>, IEmailOtpRepository
    {
        public EmailOtpRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<EmailOtp>> GetAllEmailOtpsAsync()
        {
            return await FindAll()
                        .OrderBy(otp => otp.SentAt)
                        .ToListAsync();
        }

        public async Task<EmailOtp> GetEmailOtpByIdAsync(Guid id)
        {
            return await FindByCondition(otp => otp.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<EmailOtp> GetEmailOtpByIcNumberAsync(string icNumber)
        {
            return await FindByCondition(otp => otp.IcNumber.Equals(icNumber))
                        .FirstOrDefaultAsync();
        }

        public async Task CreateEmailOtpAsync(EmailOtp otp)
        {
            Create(otp);
            await SaveAsync();
        }

        public async Task UpdateEmailOtpAsync(EmailOtp otp)
        {
            Update(otp);
            await SaveAsync();
        }

        public async Task DeleteEmailOtpAsync(EmailOtp otp)
        {
            Delete(otp);
            await SaveAsync();
        }
    }
}