using System.Linq.Expressions;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IQueryable<T> AsQueryable();
        List<T> where(Expression<Func<T, bool>> query);
        T? FirstOfDefault(Expression<Func<T, bool>> query);
    }
}
