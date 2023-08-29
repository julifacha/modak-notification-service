namespace Models
{
    public class Notification
    {
        public NotificationTypeEnum Type { get; set; }
        public User SentTo { get; set; }
        public DateTime SentAt { get; set; }
        protected Notification(NotificationTypeEnum type, User user) 
        { 
            Type = type;
            SentTo = user;
            SentAt = DateTime.Now;
        }
        public static Notification Create(NotificationTypeEnum type, User user)
        {
            return new Notification(type, user);
        }
    }
}
