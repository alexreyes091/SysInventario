
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario;
using System.Linq.Expressions;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.Repository
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly SysInventarioDbContext _context;
        public EntityRepository(SysInventarioDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context!.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public List<TEntity> where(System.Linq.Expressions.Expression<Func<TEntity, bool>> query)
        {
            return _context!.Set<TEntity>().Where(query).ToList();
        }

        public TEntity? FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> query)
        {
            return _context.Set<TEntity>().FirstOrDefault();
        }

        public TEntity? FirstOfDefault(Expression<Func<TEntity, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}
