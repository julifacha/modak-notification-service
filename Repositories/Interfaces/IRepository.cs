using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> FindAll(Func<T, bool>? predicate = null);
        T? FindOne(Func<T, bool>? predicate = null);
        T Save(T entity);
    }
}
