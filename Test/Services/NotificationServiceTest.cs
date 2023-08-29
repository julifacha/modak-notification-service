using Repositories.Interfaces;
using Services.Implementations;
using Moq;
using Models;
using Services.Interfaces;
using Services.Exceptions;

namespace Test.Services
{
    public class NotificationServiceTest
    {
        private readonly NotificationService _notificationService;

        public NotificationServiceTest()
        {
            var userRepository = new Mock<IRepository<User>>();
            var notificationRepository = new Mock<IRepository<Notification>>();
            var notificationRuleValidationService = new Mock<INotificationRuleValidationService>();
            var smtpService = new Mock<ISmtpService>();

            userRepository.Setup(s => s.FindOne(It.IsAny<Func<User, bool>>()))
                .Returns<Func<User, bool>>(expr => {
                    User[] users = new User[] {
                        User.Create("user1", "Julian", "julian.leandro.sosa@gmail.com")
                    };
                    return users.Where(expr).FirstOrDefault();
                });

            notificationRuleValidationService.Setup(s => s.ValidateNotificationRule(NotificationTypeEnum.News, "user1"))
                .Throws(new RateLimitExceededException(NotificationTypeEnum.News, "user1"));

            _notificationService = new NotificationService(userRepository.Object, notificationRepository.Object, notificationRuleValidationService.Object, smtpService.Object);
        }

        [Fact]
        public void Test_User_Not_Found()
        {
            // assert
            Assert.Throws<NotFoundException>(() => _notificationService.Send(NotificationTypeEnum.News, "user5", "Test"));
        }

        [Fact]
        public void Test_Rate_Limit_Exceeded()
        {
            // assert
            Assert.Throws<RateLimitExceededException>(() => _notificationService.Send(NotificationTypeEnum.News, "user1", "Test"));
        }
    }
}
