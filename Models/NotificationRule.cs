namespace Models
{
    public class NotificationRule
    {
        public NotificationTypeEnum NotificationType { get; set; }
        public IntervalEnum IntervalType { get; set; }
        public int IntervalValue { get; set; }
        public int Limit { get; set; }

        protected NotificationRule(NotificationTypeEnum notificationType, IntervalEnum intervalType, int intervalValue, int limit) 
        {
            NotificationType = notificationType;
            IntervalType = intervalType;
            IntervalValue = intervalValue;
            Limit = limit;
        }

        public static NotificationRule Create(NotificationTypeEnum notificationType, IntervalEnum intervalType, int intervalValue, int limit)
        {
            return new NotificationRule(notificationType, intervalType, intervalValue, limit);
        }

        public (DateTime start, DateTime end) GetInterval()
        {
            TimeSpan timespan = IntervalType switch
            {
                IntervalEnum.Second => TimeSpan.FromSeconds(IntervalValue),
                IntervalEnum.Minute => TimeSpan.FromMinutes(IntervalValue),
                IntervalEnum.Hour => TimeSpan.FromHours(IntervalValue),
                IntervalEnum.Day => TimeSpan.FromDays(IntervalValue),
                _ => throw new ArgumentException(message: "invalid interval", paramName: nameof(IntervalType)),
            };

            DateTime now = DateTime.Now;

            return (now.Add(-timespan), now);
        }
    }
}
