using Entities.Models;

namespace Entities.Extensions
{
    public static class UserExtensions
    {
        public static void Map(this User dbUser, User user)
        {
            dbUser.UserName = user.UserName;
            dbUser.EmailAddress = user.EmailAddress;
            dbUser.PhoneNumber = user.PhoneNumber;

            if (!string.IsNullOrEmpty(user.PinHash)) {
                dbUser.PinHash = user.PinHash;
            }

            dbUser.IsMigrated = user.IsMigrated;
            dbUser.HasAcceptedPrivacyPolicy = user.HasAcceptedPrivacyPolicy;
            dbUser.HasCompletedOnboarding = user.HasCompletedOnboarding;
        }
    }
}