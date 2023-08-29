using Models;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class NotificationRepository : IRepository<Notification>
    {
        private SharedContext _sharedContext;
        public NotificationRepository(SharedContext context)
        {
            _sharedContext = context;
        }
        public ICollection<Notification> FindAll(Func<Notification, bool>? predicate = null)
        {
            return _sharedContext.Notifications.Where(predicate ?? (s => true)).ToList();
        }

        public Notification? FindOne(Func<Notification, bool>? predicate = null)
        {
            return _sharedContext.Notifications.Where(predicate ?? (s => true)).FirstOrDefault();
        }

        public Notification Save(Notification entity)
        {
            _sharedContext.Notifications.Add(entity);
            return entity;
        }
    }
}
