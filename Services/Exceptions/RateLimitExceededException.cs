using Models;

namespace Services.Exceptions
{
    public class RateLimitExceededException : Exception
    {
        public RateLimitExceededException(NotificationTypeEnum notificationType, string userId)
            : base($"Rate Limit exeeded for \"{notificationType}\" for user ({userId}).")
        {
        }
    }
}
