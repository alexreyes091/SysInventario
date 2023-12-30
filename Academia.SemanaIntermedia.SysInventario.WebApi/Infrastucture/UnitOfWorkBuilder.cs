using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.EntityFrameworkCore;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture
{
    public class UnitOfWorkBuilder 
    {
        public IServiceProvider _serviceProvider;

        public UnitOfWorkBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork BuilderSysInventario()
        {
            DbContext dbContext = _serviceProvider.GetService<SysInventarioDbContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }
    }
}
