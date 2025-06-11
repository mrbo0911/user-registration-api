using MediatR;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Application.Events
{
    public record UserRegisteredEvent(User User, string OtpCode) : INotification;
}
