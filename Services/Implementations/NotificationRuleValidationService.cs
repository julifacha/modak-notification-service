using Models;
using Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;

namespace Services.Implementations
{
    public class NotificationRuleValidationService : INotificationRuleValidationService
    {
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IRepository<NotificationRule> _notificationRuleRepository;
        public NotificationRuleValidationService(IRepository<Notification> notificationRepository, IRepository<NotificationRule> notificationRuleRepository) 
        {
            _notificationRepository = notificationRepository;
            _notificationRuleRepository = notificationRuleRepository;
        }

        public void ValidateNotificationRule(NotificationTypeEnum notificationType, string userId)
        {
            NotificationRule? notificationRule = _notificationRuleRepository.FindOne(n => n.NotificationType == notificationType);

            if (notificationRule == null) 
            {
                return;
            }

            (DateTime intervalStart, DateTime intervalEnd) = notificationRule.GetInterval();

            int sentNotifications = _notificationRepository
                .FindAll(n => n.Type == notificationType &&
                                n.SentTo.Id == userId &&
                                n.SentAt >= intervalStart &&
                                n.SentAt <= intervalEnd)
                .Count();

            if (sentNotifications >= notificationRule.Limit)
            {
                throw new RateLimitExceededException(notificationType, userId);
            }
        }
    }
}
