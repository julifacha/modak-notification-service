using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ICollection<T> _savedEntites;

        public ICollection<T> FindAll(Func<T, bool>? predicate = null)
        {
            return _savedEntites.Where(predicate ?? (s => true)).ToList();
        }

        public T? FindOne(Func<T, bool>? predicate = null)
        {
            return _savedEntites.Where(predicate ?? (s => true)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _savedEntites.Add(entity);
            return entity;
        }
    }
}
