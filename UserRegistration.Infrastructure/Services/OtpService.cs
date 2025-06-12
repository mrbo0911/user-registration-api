using System;
using System.Threading.Tasks;
using UserRegistration.Domain.Services;

namespace UserRegistration.Infrastructure.Services
{
    public class OtpService : IOtpService
    {
        public async Task<int> GeneratePhoneOtpAsync(string phoneNumber, string icNumber)
        {
            var otp = new Random().Next(1000, 9999);

            // Simulate async OTP sending (e.g., external SMS gateway)
            await Task.Run(() =>
            {
                Console.WriteLine($"OTP {otp} sent to phone {phoneNumber}");
            });

            return otp;
        }

        public async Task<int> GenerateEmailOtpAsync(string emailAddress, string icNumber)
        {
            var otp = new Random().Next(1000, 9999);

            // Simulate async OTP sending (e.g., external email provider)
            await Task.Run(() =>
            {
                Console.WriteLine($"OTP {otp} sent to email {emailAddress}");
            });

            return otp;
        }
    }
}
