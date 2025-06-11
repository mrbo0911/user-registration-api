using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Extensions;
using UserRegistration.Domain.Interfaces;
using UserRegistration.Infrastructure.Persistence;

namespace UserRegistration.Infrastructure.Repositories
{
    public class OtpRepository : RepositoryBase<Otp>, IOtpRepository
    {
        private ApplicationDbContext _repositoryContext;

        public OtpRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Otp>> GetAllOtpsAsync()
        {
            return await FindAll()
                        .OrderBy(otp => otp.SentAt)
                        .ToListAsync();
        }

        public async Task<Otp> GetOtpByIdAsync(Guid id)
        {
            return await FindByCondition(otp => otp.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<Otp> GetOtpByPhoneNumberAsync(string phoneNumber)
        {
            return await FindByCondition(otp => otp.PhoneNumber.Equals(phoneNumber))
                        .FirstOrDefaultAsync();
        }

        public async Task CreateOtpAsync(Otp otp)
        {
            Create(otp);
            await SaveAsync();
        }

        public async Task UpdateOtpAsync(Otp dbOtp, Otp otp)
        {
            dbOtp.Map(otp);
            Update(dbOtp);
            await SaveAsync();
        }

        public async Task DeleteOtpAsync(Otp otp)
        {
            Delete(otp);
            await SaveAsync();
        }
    }
}