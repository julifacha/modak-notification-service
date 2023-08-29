using Models;

namespace Services.Interfaces
{
    public interface INotificationService
    {
        void Send(NotificationTypeEnum type, string userId, string message);
    }
}
