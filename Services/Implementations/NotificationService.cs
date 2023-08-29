using Models;
using Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;

namespace Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Notification> _notificationRepository;
        private readonly INotificationRuleValidationService _notificationRuleValidationService;
        private readonly ISmtpService _smtpService;
        public NotificationService(IRepository<User> userRepository, IRepository<Notification> notificationRepository, INotificationRuleValidationService notificationRuleValidationService, ISmtpService smtpService) 
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _notificationRuleValidationService = notificationRuleValidationService;
            _smtpService = smtpService;
        }

        public void Send(NotificationTypeEnum type, string userId, string message)
        {
            User? user = _userRepository.FindOne(u => u.Id == userId);

            if (user == null) 
            {
                throw new NotFoundException(nameof(User), userId);
            }

            _notificationRuleValidationService.ValidateNotificationRule(type, userId);

            _smtpService.SendEmail(user.Email, type.ToString(), message);

            _notificationRepository.Save(Notification.Create(type, user));
        }
    }
}
