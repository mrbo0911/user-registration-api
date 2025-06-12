using System.Threading.Tasks;

namespace UserRegistration.Domain.Services
{
    public interface IOtpService
    {
        Task<int> GeneratePhoneOtpAsync(string phoneNumber, string icNumber);
        Task<int> GenerateEmailOtpAsync(string emailAddress, string icNumber);
    }
}
