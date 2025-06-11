using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Extensions
{
    public static class OtpExtensions
    {
        public static void Map(this Otp dbOtp, Otp otp)
        {
            dbOtp.Code = otp.Code;
            dbOtp.SentAt = otp.SentAt;
            dbOtp.IsVerified = otp.IsVerified;
            dbOtp.ExpiresAt = otp.ExpiresAt;
            dbOtp.IsExpired = otp.IsExpired;
        }
    }
}