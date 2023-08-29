using Models;

namespace Services.Interfaces
{
    public interface INotificationRuleValidationService
    {
        void ValidateNotificationRule(NotificationTypeEnum notificationType, string userId);
    }
}
