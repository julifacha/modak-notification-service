using Models;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class NotificationRuleRepository : IRepository<NotificationRule>
    {
        private SharedContext _sharedContext;
        public NotificationRuleRepository(SharedContext context)
        {
            _sharedContext = context;
        }
        public ICollection<NotificationRule> FindAll(Func<NotificationRule, bool>? predicate = null)
        {
            return _sharedContext.NotificationRules.Where(predicate ?? (s => true)).ToList();
        }

        public NotificationRule? FindOne(Func<NotificationRule, bool>? predicate = null)
        {
            return _sharedContext.NotificationRules.Where(predicate ?? (s => true)).FirstOrDefault();
        }

        public NotificationRule Save(NotificationRule entity)
        {
            _sharedContext.NotificationRules.Add(entity);
            return entity;
        }
    }
}
