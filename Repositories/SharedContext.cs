using Models;

namespace Repositories
{
    public class SharedContext
    {
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public ICollection<NotificationRule> NotificationRules { get; set; } = new HashSet<NotificationRule>();
        public ICollection<User> Users { get; set; } = new HashSet<User>();

        public SharedContext() 
        {
            SeedUsers();
            SeedNotificationRules();
        }  

        public void SeedNotificationRules()
        {
            NotificationRules.Add(NotificationRule.Create(NotificationTypeEnum.Status, IntervalEnum.Minute, 1, 2));
            NotificationRules.Add(NotificationRule.Create(NotificationTypeEnum.News, IntervalEnum.Day, 1, 1));
            NotificationRules.Add(NotificationRule.Create(NotificationTypeEnum.Marketing, IntervalEnum.Hour, 1, 3));
        }

        public void SeedUsers()
        {
            Users.Add(User.Create("user1", "Julian", "julian.leandro.sosa@gmail.com"));
            Users.Add(User.Create("user2", "Robert", "robert@test.com"));
            Users.Add(User.Create("user3", "Martha", "martha@test.com"));
        }
    }
}
