using Models;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class UserRepository : IRepository<User>
    {
        private SharedContext _sharedContext;
        public UserRepository(SharedContext context) 
        { 
            _sharedContext = context;
        }
        public ICollection<User> FindAll(Func<User, bool>? predicate = null)
        {
            return _sharedContext.Users.Where(predicate ?? (s => true)).ToList();
        }

        public User? FindOne(Func<User, bool>? predicate = null)
        {
            return _sharedContext.Users.Where(predicate ?? (s => true)).FirstOrDefault();
        }

        public User Save(User entity)
        {
            _sharedContext.Users.Add(entity);
            return entity;
        }
    }
}
